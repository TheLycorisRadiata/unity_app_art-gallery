using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMovement : MonoBehaviour
{
    public static float horizontalInput, verticalInput, sideStepInput;
    private static float directionalSpeed, rotationSpeed;

    void Start()
    {
        horizontalInput = 0f;
        verticalInput = 0f;
        sideStepInput = 0f;
        directionalSpeed = 10f;
        rotationSpeed = directionalSpeed * 7f;
    }

    void FixedUpdate()
    {
        horizontalInput = UserInput.movementVector.x;
        verticalInput = UserInput.movementVector.y;
        sideStepInput = UserInput.sideStepInput;

        transform.Translate(new Vector3(sideStepInput, 0f, verticalInput) * directionalSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0f, horizontalInput, 0f) * rotationSpeed * Time.deltaTime);
    }
}
