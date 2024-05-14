using System;
using UnityEngine;
using UnityEngine.UI;

public class MonitorCursorInputListener : MonoBehaviour, ICursorHoverable
{
    public Action<Vector2> CursorHover; //Vector2 parameter  is textureCoord
    public Action CursorEnter; 
    public Action CursorExit; 


    [SerializeField] private RenderTexture _renderTexture;

    public void OnCursorEnter(RaycastHit hit)
    {
        CursorEnter.Invoke();
    }

    public void OnCursorHover(RaycastHit hit)
    {
        CursorHover.Invoke(hit.textureCoord);  
    }

    public void OnCursorExit()
    {
        CursorExit.Invoke();
    }
}
