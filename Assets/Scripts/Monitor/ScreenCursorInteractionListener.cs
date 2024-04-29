using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class ScreenCursorInteractionListener : MonoBehaviour, ICursorHoverable
{
    [SerializeField] private RectTransform _cursor;
    [SerializeField] private RenderTexture _renderTexture;

    public void OnCursorHover(RaycastHit hit)
    {
        UpdateCursorPosition(TranslateTextureCoordToRectPoint(hit.textureCoord, 
            new Vector2(_renderTexture.width, _renderTexture.height)));
    }

    private void UpdateCursorPosition(Vector2 rectPoint)
    {
        _cursor.anchoredPosition = rectPoint;
    }

    private Vector2 TranslateTextureCoordToRectPoint(Vector2 textureCoord, Vector2 textureResolution)
    {
        float rectPointX = Mathf.Lerp(-(textureResolution.x / 2), textureResolution.x / 2,
            textureCoord.x);
        float rectPointY = Mathf.Lerp(-(textureResolution.y / 2), textureResolution.y / 2,
            textureCoord.y);
        return new Vector2(rectPointX, rectPointY);
    }
}
