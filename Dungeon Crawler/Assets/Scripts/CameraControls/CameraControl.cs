using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;

    // Update is called once per frame
    void Update()
    {
        if (gameInput.IsMoving() && Time.time >= gameInput.GetNextMoveTime())
            gameInput.MovePlayer();

        if (gameInput.IsRotating() && Time.time >= gameInput.GetNextRotateTime())
            gameInput.RotatePlayer();
    }

    void Awake()
    {
        gameInput.PlayerObject = this.gameObject; // Set camera reference inside input class
    }
}
