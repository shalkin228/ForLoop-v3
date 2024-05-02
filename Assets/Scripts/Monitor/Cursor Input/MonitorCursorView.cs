using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MonitorCursorView : MonoBehaviour
{
    private RectTransform _rectTransform;
    private Image _image;

    public void SetRectPosition(Vector2 position) => _rectTransform.anchoredPosition = position;
    public void SetVisibility(bool visibility) => _image.enabled = visibility;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();
    }
}
