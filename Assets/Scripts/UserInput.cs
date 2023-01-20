using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    private static float directionalSpeed, rotationSpeed;
    private static float horizontalInput, verticalInput;

    void Start()
    {
        directionalSpeed = 10f;
        rotationSpeed = 40f;
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(0f, 0f, verticalInput) * directionalSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0f, horizontalInput, 0f) * rotationSpeed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 movementVector = ctx.ReadValue<Vector2>();
        horizontalInput = movementVector.x;
        verticalInput = movementVector.y;
    }

    public void OnLook(InputAction.CallbackContext ctx)
    {
        Vector2 cameraVector = ctx.ReadValue<Vector2>();
        Debug.Log(cameraVector.x);
        Debug.Log(cameraVector.y);
    }

    public void OnFire(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
            Debug.Log("Fire!");
    }
}
