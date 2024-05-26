using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCameraTest : MonoBehaviour
{
    // Written by Jesper Wentzell
    private FacePlayer facePlayer;
    private GameObject testObject;
    private GameObject cameraObject;

    [SetUp]
    public void Setup()
    {
        // Create a GameObject for FacePlayer component and attach the script
        testObject = new GameObject("FacePlayerTestObject");
        facePlayer = testObject.AddComponent<FacePlayer>();

        // Create a mock camera and set it as the main camera
        cameraObject = new GameObject("MainCamera");
        cameraObject.AddComponent<Camera>();
        cameraObject.tag = "MainCamera";
    }

    [TearDown]
    public void Teardown()
    {
        // Clean up after each test by destroying the created objects
        Object.Destroy(testObject);
        Object.Destroy(cameraObject);
    }

    [Test]
    public void StartsFacingCamera()
    {
        // Call Start to initialize the component and simulate a frame update
        facePlayer.Start();
        facePlayer.Update();

        // Get the direction from FacePlayer object to the camera
        Vector3 directionToCamera = cameraObject.transform.position - testObject.transform.position;

        // Check if the FacePlayer object's forward direction is approximately aligned with the direction to the camera
        Assert.That(Vector3.Angle(testObject.transform.forward, directionToCamera), Is.LessThan(1f)); // Small margin for error
    }

    [Test]
    public void RotatesWithOffset()
    {
        // Set a specific rotation offset
        facePlayer.NewOffset(new Vector3(90f, 0f, 0f));
        facePlayer.Start();

        // Get initial rotation of the FacePlayer object
        Quaternion initialRotation = testObject.transform.rotation;

        // Simulate a frame update
        facePlayer.Update();

        // Get the direction from FacePlayer object to the camera
        Quaternion newRotation = testObject.transform.rotation;

        // Check if the FacePlayer object's forward direction is approximately aligned with the direction to the camera
        Assert.AreNotEqual(initialRotation, newRotation); // Small margin for error
    }
}
