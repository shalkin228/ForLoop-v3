using System;
using UnityEngine;

public class MonitorController : MonoBehaviour
{
    [SerializeField] private MonitorCursorInputListener _cursorInputListener;
    [SerializeField] private MonitorCursorInputHandler _cursorInputHandler;

    private void Awake()
    {
        _cursorInputListener.CursorEnter += OnCursorEnter;
        _cursorInputListener.CursorHover += OnCursorHover;
        _cursorInputListener.CursorExit += OnCursorExit;
    }
    private void OnCursorEnter()
    {
        Cursor.visible = false;
        _cursorInputHandler.OnCursorEnter();
    }

    private void OnCursorHover(Vector2 textureCoord)
    {
        _cursorInputHandler.OnCursorInput(textureCoord);
    }

    private void OnCursorExit()
    {
        Cursor.visible = true;
        _cursorInputHandler.OnCursorExit();
    }
}
