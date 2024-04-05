using UnityEngine;

public class CameraTestMovement : MonoBehaviour
{
    public GameObject targetObject;
    public float moveDistance = 6.0f;
    public LayerMask wallLayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w")) // Press "w" on keyboard
        {
            // Get the current forward direction
            Vector3 forwardDirection = targetObject.transform.forward.normalized;  

            // Multiple raycasts for 3D collision detection
            if (CanMove(forwardDirection))
            {
                targetObject.transform.position += forwardDirection * moveDistance; // Move
            }
        }
        else if (Input.GetKeyDown("a")) // Press "a" on keyboard
        {
            // Rotate the object 90 degrees on the Y-axis
            targetObject.transform.Rotate(0f, -90f, 0f);
        }
        else if (Input.GetKeyDown("d")) // Press "d" on keyboard
        {
            // Rotate the object 90 degrees on the Y-axis
            targetObject.transform.Rotate(0f, 90f, 0f);
        }
    }
    private bool CanMove(Vector3 direction)
    {
        // Adjust number of raycasts and offset positions
        Vector3 offset = new Vector3(0, 0.5f, 0); // Offset for slightly elevated raycasts 

        /*
         Raycasting is a lot like sending out a laser and checking if it hits something within a certain range, in this case moveDistance. 
         The offset helps with consistency and allows for player to have a box collider.
         It will only detect collitions in the wallLayer and ignore everything else i.e only detecting walls.
         - Jesper
         */
        return !Physics.Raycast(targetObject.transform.position + offset, direction, out RaycastHit hit, moveDistance, wallLayer);


    }
}
