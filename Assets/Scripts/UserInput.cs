using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static Vector2 movementVector, cameraVector;
    public static float sideStepInput;

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movementVector = ctx.ReadValue<Vector2>();
    }

    public void OnSideStep(InputAction.CallbackContext ctx)
    {
        sideStepInput = ctx.ReadValue<float>();
    }

    public void OnLook(InputAction.CallbackContext ctx)
    {
        cameraVector = ctx.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
            Debug.Log("Fire!");
    }
}
