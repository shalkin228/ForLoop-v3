using UnityEngine;

public interface ICursorHoverable
{
    void OnCursorEnter(RaycastHit hit);
    void OnCursorHover(RaycastHit hit);
    void OnCursorExit();
}
