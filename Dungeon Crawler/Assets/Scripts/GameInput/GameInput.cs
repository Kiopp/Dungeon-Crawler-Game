using UnityEngine;
using System.Collections;
using System.Net;
using TMPro;

public class GameInput : MonoBehaviour
{
    /*
        GameInput handles player inputs using the new unity input actions
        
        Code written by Jesper Wentzell
    */
    [SerializeField] private float moveDistance = 6.0f;
    [SerializeField] private float moveDelay = 0.5f;  // Delay between movements
    [SerializeField] private float rotateDelay = 0.5f; // Delay between rotations
    [SerializeField] private LayerMask wallLayer;
    private PlayerInputActions playerInputActions;

    // Movement/rotation
    private float nextMoveTime = 0.0f;
    private float nextRotateTime = 0.0f;
    private bool isMoving = false;
    private bool keepMoving = false;
    private bool startMove = false;
    private bool isRotating = false;
    private bool keepRotating = false;
    private bool startRotate = false;
    private GameObject playerObject = null;
    public GameObject PlayerObject
    {
        get { return playerObject; }
        set { playerObject = value; }
    }

    // Run once when first initialized, similar to a constructor
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        // Subscribe to started events, started is called on initial keypress
        playerInputActions.Player.Move.started += ctx => OnMoveStart();
        playerInputActions.Player.Rotate.started += ctx => OnRotateStart();

        // Sybscribe to canceled events, canceled is called when key is released
        playerInputActions.Player.Move.canceled += ctx => OnMoveRelease();
        playerInputActions.Player.Rotate.canceled += ctx => OnRotateRelease();
    }

    #region EventMethods
    public void OnMoveStart()
    {
        keepMoving = true;
        startMove = true;
        TryMovePlayer();
    }
    public void OnMoveRelease()
    {
        keepMoving = false;
    }

    public void OnRotateStart()
    {
        keepRotating = true;
        startRotate = true;
        TryRotatePlayer();
    }
    public void OnRotateRelease()
    {
        keepRotating = false;
    }
    #endregion

    #region PublicGetMethods
    public float GetNextMoveTime()
    {
        return nextMoveTime;
    }

    public float GetNextRotateTime()
    {
        return nextRotateTime;
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    public bool IsRotating()
    {
        return isRotating;
    }
    #endregion

    public void TryMovePlayer()
    {
        // Check if key is just pressed or if timer allows move
        if (playerObject != null && keepMoving && Time.time >= nextMoveTime || startMove)
        {
            // Only run once on start
            startMove = false;

            // Get player movement input
            bool moving = playerInputActions.Player.Move.IsPressed();

            // Update timer
            nextMoveTime = Time.time + moveDelay + 0.1f; // Extra .1 second delay for coroutine to finish

            if (moving && !isRotating)
            {
                // Get the current forward direction
                Vector3 forwardDirection = playerObject.transform.forward.normalized;

                // Multiple raycasts for 3D collision detection
                if (CanMove(forwardDirection, playerObject))
                {
                    Debug.Log("Movement start");
                    //playerObject.transform.position += forwardDirection * moveDistance; // LEGACY CODE PLEASE REMOVE

                    // Lock rotations
                    isMoving = true;

                    StartCoroutine(SmoothMove(forwardDirection * moveDistance));
                    
                    
                }
            }
        }
    }

    // Coroutine for smooth movement
    IEnumerator SmoothMove(Vector3 targetOffset)
    {
        Vector3 startingPosition = playerObject.transform.position;
        Vector3 targetPosition = startingPosition + targetOffset;
        float startTime = Time.time;

        while (playerObject.transform.position != targetPosition)
        {
            isMoving = true;
            float timeFraction = (Time.time - startTime) / moveDelay; // Use moveDelay for duration 
            playerObject.transform.position = Vector3.Lerp(startingPosition, targetPosition, timeFraction);
            yield return null;
        }

        // Unlock rotations
        isMoving = false;

        // Ensure the object ends exactly at the final position
        playerObject.transform.position = targetPosition;
        
    }

    public void TryRotatePlayer()
    {
        // Check if key is just pressed or if timer allows rotation
        if (playerObject != null && keepRotating && Time.time >= nextRotateTime || startRotate)
        {
            // Only run once on start
            startRotate = false;

            // Get player rotation input
            float rotationValue = playerInputActions.Player.Rotate.ReadValue<float>();

            // Update timer
            nextRotateTime = Time.time + rotateDelay + 0.1f; // Extra .1 second delay for coroutine to finish

            if (Mathf.Abs(rotationValue) > 0f && !isMoving) // Check for any rotation value
            {
                //Debug.Log("Rotated");
                float rotationAmount = rotationValue > 0 ? -90f : 90f;

                // Lock movement
                isRotating = true;

                StartCoroutine(SmoothRotate(rotationAmount));
            }
        }
    }

    // Coroutine for smooth rotations
    IEnumerator SmoothRotate(float rotationAmount) // Expects rotation in degrees
    {
        Quaternion startingRotation = playerObject.transform.rotation;
        Quaternion targetRotation = startingRotation * Quaternion.Euler(0, rotationAmount, 0);
        float startTime = Time.time;

        while (playerObject.transform.rotation != targetRotation)
        {
            float timeFraction = (Time.time - startTime) / rotateDelay; // Use moveDelay for duration 
            playerObject.transform.rotation = Quaternion.Slerp(startingRotation, targetRotation, timeFraction);
            yield return null;
        }

        // Unlock movement
        isRotating = false;

        // Ensure the object ends exactly at the final rotation
        playerObject.transform.rotation = targetRotation;
    }

    private bool CanMove(Vector3 direction, GameObject source)
    {
        // Adjust number of raycasts and offset positions
        Vector3 offset = new Vector3(0, 0.5f, 0); // Offset for slightly elevated raycasts 

        /*
         Raycasting is a lot like sending out a laser and checking if it hits something within a certain range, in this case moveDistance. 
         The offset helps with consistency and allows for player to have a box collider.
         It will only detect walls.
         - Jesper
         */
        return !Physics.Raycast(source.transform.position + offset, direction, out RaycastHit hit, moveDistance, wallLayer);
    }
}
