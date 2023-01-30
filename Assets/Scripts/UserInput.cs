using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static bool isCursorWithinAppWindow;
    public static Vector2 movementVector, cameraVector;
    public static float sideStepInput;
    public static bool click;
    private static Vector2 screenDimensions;
    private static CursorAppearance cursorAppearance;

    void Awake()
    {
        cursorAppearance = GameObject.Find("App Manager").GetComponent<CursorAppearance>();
    }

    void Start()
    {
        screenDimensions = new Vector2(Screen.width, Screen.height);
    }

    public void OnCursorPosition(InputAction.CallbackContext ctx)
    {
        Vector2 position = ctx.ReadValue<Vector2>();
        isCursorWithinAppWindow = !(position.x < 0 || position.x > screenDimensions.x || position.y < 0 || position.y > screenDimensions.y);
    }

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
        if (isCursorWithinAppWindow)
            cameraVector = ctx.ReadValue<Vector2>();
        else
            cameraVector = Vector2.zero;
    }

    public void OnFire(InputAction.CallbackContext ctx)
    {
        click = ctx.canceled ? false : true;
        cursorAppearance.Click();
    }
}
