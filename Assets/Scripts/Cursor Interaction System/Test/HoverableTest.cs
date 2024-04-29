using UnityEngine;

public class HoverableTest : MonoBehaviour, ICursorHoverable
{
    public void OnCursorHover(RaycastHit hit)
    {
        Debug.Log("OnCursorHover triggered on " + gameObject.name);
    }
}
