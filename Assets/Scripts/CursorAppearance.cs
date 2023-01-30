using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAppearance : MonoBehaviour
{
    public enum CursorState { HARDWARE, DEFAULT, CLICKABLE_TARGET, CLICKED_TARGET };
    private static CursorState state;

    [SerializeField] private Texture2D defaultTexture, clickableTargetTexture, clickedTargetTexture;
    private static Vector2 defaultHotspot = new Vector2(20f, 5f);
    private static Vector2 targetHotspot = new Vector2(64f, 64f);

    void Awake()
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
        if (UserInput.click)
        {
            if (state == CursorState.CLICKABLE_TARGET)
                ClickedTarget();
        }
        // On click release, switch back from the focus
        else
        {
            if (state == CursorState.CLICKED_TARGET)
                ClickableTarget();
        }
    }

    private void Hardware()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        state = CursorState.HARDWARE;
    }

    private void Default()
    {
        Cursor.SetCursor(defaultTexture, defaultHotspot, CursorMode.ForceSoftware);
        state = CursorState.DEFAULT;
    }

    private void ClickableTarget()
    {
        Cursor.SetCursor(clickableTargetTexture, targetHotspot, CursorMode.ForceSoftware);
        state = CursorState.CLICKABLE_TARGET;
    }

    private void ClickedTarget()
    {
        Cursor.SetCursor(clickedTargetTexture, targetHotspot, CursorMode.ForceSoftware);
        state = CursorState.CLICKED_TARGET;
    }
}
