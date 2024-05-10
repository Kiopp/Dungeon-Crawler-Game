using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    private Transform cameraTransform;
    [SerializeField] private Vector3 rotationOffset = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        // Get the transform object from the main camera
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Call built-in LookAt method
        transform.LookAt(cameraTransform);

        // Adjust offset rotation
        transform.Rotate(rotationOffset);
    }
}
