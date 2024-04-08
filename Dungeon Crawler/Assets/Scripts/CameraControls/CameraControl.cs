using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;

    // Update is called once per frame
    void Update()
    {
        gameInput.TryMovePlayer();

        gameInput.TryRotatePlayer();
    }

    void Awake()
    {
        gameInput.PlayerObject = this.gameObject; // Set camera reference inside input class
    }
}
