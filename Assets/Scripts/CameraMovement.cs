using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private static float horizontalInput, verticalInput;
    private static float horizontalLimit, verticalLimit;
    private static float sensitivity;

    void Start()
    {
        horizontalInput = 0f;
        verticalInput = 0f;
        horizontalLimit = 70f;
        verticalLimit = 35f;
        sensitivity = 0.5f;
    }

    void LateUpdate()
    {
        // Reset the camera position if the user moves
        if (UserMovement.horizontalInput != 0f || UserMovement.verticalInput != 0f || UserMovement.sideStepInput != 0f)
        {
            horizontalInput = 0f;
            verticalInput = 0f;
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            return;
        }

        // Update the variables
        horizontalInput += UserInput.cameraVector.x * sensitivity;
        verticalInput += -UserInput.cameraVector.y * sensitivity;

        // Clamp them
        horizontalInput = horizontalInput < -horizontalLimit ? -horizontalLimit : horizontalInput > horizontalLimit ? horizontalLimit : horizontalInput;
        verticalInput = verticalInput < -verticalLimit ? -verticalLimit : verticalInput > verticalLimit ? verticalLimit : verticalInput;

        // Rotate the camera
        transform.localRotation = Quaternion.Euler(verticalInput, horizontalInput, 0f);
    }
}
