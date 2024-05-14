using UnityEngine;

public interface ICursorClickable : ICursorHoverable
{
    void OnCursorClick(RaycastHit hit);
}
