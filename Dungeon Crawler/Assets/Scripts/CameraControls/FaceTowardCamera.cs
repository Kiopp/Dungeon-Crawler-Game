using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    // Written by Jesper Wentzell
    private Transform cameraTransform;
    [SerializeField] private Vector3 rotationOffset = Vector3.zero;

    // Start is called before the first frame update
    public void Start()
    {
        // Get the transform object from the main camera
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    public void Update()
    {
        // Call built-in LookAt method
        transform.LookAt(cameraTransform);

        // Adjust offset rotation
        transform.Rotate(rotationOffset);
    }

    // Used for testing
    public void NewOffset(Vector3 newOffset)
    {
        this.rotationOffset = newOffset;
    }
}
