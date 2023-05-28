using UnityEngine;

public class CursorAppearance : MonoBehaviour
{
    public enum CursorState { HARDWARE, DEFAULT, CLICKABLE_TARGET, CLICKED_TARGET };
    private static CursorState _state;

    [SerializeField] private Texture2D _defaultTexture, _clickableTargetTexture, _clickedTargetTexture;
    private static Vector2 _defaultHotspot = new Vector2(20f, 5f);
    private static Vector2 _targetHotspot = new Vector2(64f, 64f);

    private void Awake()
    {
        Default();
    }

    public void ChangeCursorAppearance(CursorState newState)
    {
        switch (newState)
        {
            case CursorState.HARDWARE:
                Hardware();
                break;
            case CursorState.CLICKABLE_TARGET:
                ClickableTarget();
                break;
            case CursorState.CLICKED_TARGET:
                ClickedTarget();
                break;
            default:
                Default();
                break;
        }
    }

    public void Click()
    {
        // On click, focus from "clickable" to "clicked"
        if (UserInput.Click)
        {
            if (_state == CursorState.CLICKABLE_TARGET)
                ClickedTarget();
        }
        // On click release, switch back from the focus
        else
        {
            if (_state == CursorState.CLICKED_TARGET)
                ClickableTarget();
        }
    }

    private void Hardware()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        _state = CursorState.HARDWARE;
    }

    private void Default()
    {
        Cursor.SetCursor(_defaultTexture, _defaultHotspot, CursorMode.ForceSoftware);
        _state = CursorState.DEFAULT;
    }

    private void ClickableTarget()
    {
        Cursor.SetCursor(_clickableTargetTexture, _targetHotspot, CursorMode.ForceSoftware);
        _state = CursorState.CLICKABLE_TARGET;
    }

    private void ClickedTarget()
    {
        Cursor.SetCursor(_clickedTargetTexture, _targetHotspot, CursorMode.ForceSoftware);
        _state = CursorState.CLICKED_TARGET;
    }
}
