using UnityEngine;

public class HoverableTest : MonoBehaviour, ICursorHoverable
{
    public void OnCursorEnter(RaycastHit hit)
    {
        Debug.Log("OnCursorEnter triggered on " + gameObject.name);
    }

    public void OnCursorExit()
    {
        Debug.Log("OnCursorExit triggered on " + gameObject.name);
    }

    public void OnCursorHover(RaycastHit hit)
    {
        Debug.Log("OnCursorHover triggered on " + gameObject.name);
    }
}
