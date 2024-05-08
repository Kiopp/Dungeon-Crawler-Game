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
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cameraTransform);
        transform.Rotate(rotationOffset);
    }
}
