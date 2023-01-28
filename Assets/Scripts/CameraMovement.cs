using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private static float verticalInput, verticalLimit, sensitivity;

    void Start()
    {
        verticalInput = 0f;
        verticalLimit = 35f;
        sensitivity = 0.5f;
    }

    void LateUpdate()
    {
        // The camera horizontal movement rotates the user, and the camera is the user's child so it already rotates with it
        // All that is left to do is the vertical rotation

        // Update the input with the sensitivity
        verticalInput += -UserInput.cameraVector.y * sensitivity;

        // Clamp the input
        verticalInput = verticalInput < -verticalLimit ? -verticalLimit : verticalInput > verticalLimit ? verticalLimit : verticalInput;

        // Rotate the camera
        transform.localRotation = Quaternion.Euler(verticalInput, 0f, 0f);
    }
}
