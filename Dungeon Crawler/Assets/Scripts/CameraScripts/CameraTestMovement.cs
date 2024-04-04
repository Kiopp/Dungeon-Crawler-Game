using UnityEngine;

public class CameraTestMovement : MonoBehaviour
{
    public GameObject targetObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w")) // Press "w" on keyboard
        {
            Vector3 forwardDirection = targetObject.transform.forward.normalized;  // Get the current forward direction

            // Check direction
            if (forwardDirection.x > 0.5f)  // Approximately facing positive X
                targetObject.transform.position += new Vector3(6, 0, 0);
            else if (forwardDirection.x < -0.5f) // Approximately facing negative X 
                targetObject.transform.position += new Vector3(-6, 0, 0);
            else if (forwardDirection.z > 0.5f)  // Approximately facing positive Z
                targetObject.transform.position += new Vector3(0, 0, 6);
            else if (forwardDirection.z < -0.5f) // Approximately facing negative Z
                targetObject.transform.position += new Vector3(0, 0, -6);
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
}
