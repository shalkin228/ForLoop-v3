using UnityEngine;

public abstract class MonitorCursorInputHandler : MonoBehaviour
{
    public abstract void OnCursorEnter();

    public abstract void OnCursorExit();

    public abstract void OnCursorInput(Vector2 normalizedPosition);
}
