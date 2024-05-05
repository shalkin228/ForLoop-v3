using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class MonitorCursorInputHandler : MonoBehaviour
{
    [SerializeField] private MonitorCursorView _cursorView;
    private RectTransform _rectTransform;
    private GraphicRaycaster _raycaster;

    public void OnCursorEnter()
    {
        _cursorView.SetVisibility(true);
    }

    public void OnCursorExit()
    {
        _cursorView.SetVisibility(false);
    }

    public void OnCursorInput(Vector2 normalizedPosition)
    {
        UpdateCursorViewPosition(normalizedPosition);

        Vector2 cursorPosition = GetCursorPositionWithNormalizedPosition(normalizedPosition);

        PointerEventData cursorEvent = new PointerEventData(EventSystem.current);
        cursorEvent.position = cursorPosition;

        ExecuteMouseDownAndUpEvents(GetRaycastResults(cursorEvent), cursorEvent);
    }

    private void UpdateCursorViewPosition(Vector2 normalizedPosition)
    {
        Vector2 canvasSizeDelta = _rectTransform.sizeDelta;
        float cursorPositionX = Mathf.Lerp(-(canvasSizeDelta.x / 2), canvasSizeDelta.x / 2,
            normalizedPosition.x);
        float cursorPositionY = Mathf.Lerp(-(canvasSizeDelta.y / 2), canvasSizeDelta.y / 2,
            normalizedPosition.y);
        _cursorView.SetRectPosition(new Vector2(cursorPositionX, cursorPositionY));
    }

    private Vector2 GetCursorPositionWithNormalizedPosition(Vector2 normalizedPosition)
    {
        return new Vector2(normalizedPosition.x * _rectTransform.sizeDelta.x,
            normalizedPosition.y * _rectTransform.sizeDelta.y); 
    }

    private List<RaycastResult> GetRaycastResults(PointerEventData cursorEvent)
    {
        List<RaycastResult> results = new();
        _raycaster.Raycast(cursorEvent, results);
        return results;
    }

    private void ExecuteMouseDownAndUpEvents(List<RaycastResult> raycastResults, PointerEventData cursorEvent)
    {
        bool isMouseDown = Input.GetMouseButtonDown(0);
        bool isMouseUp = Input.GetMouseButtonUp(0);

        foreach (var raycastResult in raycastResults)
        {
            //ToDo: ExecuteEvents.pointerEnterHandler ExecuteEvents.pointerExitHandler
            // Make the select and deselect
            // https://youtu.be/fXsdK2umVmM?t=184

            if (isMouseDown)
            {
                ExecuteEvents.Execute(raycastResult.gameObject, cursorEvent,
                    ExecuteEvents.pointerDownHandler);
            }
            else if (isMouseUp)
            {
                ExecuteEvents.Execute(raycastResult.gameObject, cursorEvent,
                    ExecuteEvents.pointerUpHandler);
                ExecuteEvents.Execute(raycastResult.gameObject, cursorEvent,
                    ExecuteEvents.pointerClickHandler);
            }
        }
    }

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _raycaster = GetComponent<GraphicRaycaster>();

        _cursorView.SetVisibility(false);
    }
}
