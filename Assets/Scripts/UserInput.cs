using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static bool IsCursorWithinAppWindow;
    public static Vector2 MovementVector, CameraVector;
    public static float SideStepInput;
    public static bool Click;
    private static Vector2 _screenDimensions;
    private static CursorAppearance _cursorAppearance;

    private void Awake()
    {
        _cursorAppearance = GameObject.Find("Cursors").GetComponent<CursorAppearance>();
    }

    private void Start()
    {
        _screenDimensions = new Vector2(Screen.width, Screen.height);
    }

    public void OnCursorPosition(InputAction.CallbackContext ctx)
    {
        Vector2 position = ctx.ReadValue<Vector2>();
        IsCursorWithinAppWindow = !(position.x < 0 || position.x > _screenDimensions.x || position.y < 0 || position.y > _screenDimensions.y);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        MovementVector = ctx.ReadValue<Vector2>();
    }

    public void OnSideStep(InputAction.CallbackContext ctx)
    {
        SideStepInput = ctx.ReadValue<float>();
    }

    public void OnLook(InputAction.CallbackContext ctx)
    {
        if (IsCursorWithinAppWindow)
            CameraVector = ctx.ReadValue<Vector2>();
        else
            CameraVector = Vector2.zero;
    }

    public void OnFire(InputAction.CallbackContext ctx)
    {
        Click = ctx.canceled ? false : true;
        _cursorAppearance.Click();
    }
}
