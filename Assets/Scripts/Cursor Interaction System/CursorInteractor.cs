using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CursorInteractor : MonoBehaviour
{
    [SerializeField] private float _cursorRaycastMaxDistance = 20;
    private Vector2 _mousePosition => Input.mousePosition;
    private bool _isMouseButtonDown => Input.GetMouseButtonDown(0);
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (!RaycastCursor(out ICursorHoverable hoverable, out RaycastHit hit)) return;

        hoverable.OnCursorHover(hit);

        if (_isMouseButtonDown)
            HandleMouseButtonDownOnHoverable(hoverable, hit);
    }

    private bool RaycastCursor(out ICursorHoverable hoverable, out RaycastHit hit)
    {
        hoverable = null;
        Ray mouseRay = _camera.ScreenPointToRay(_mousePosition);
        bool didRaycastHit = Physics.Raycast(mouseRay, out hit, _cursorRaycastMaxDistance);

        if (!didRaycastHit) return false;

        hoverable = hit.collider.GetComponent<ICursorHoverable>();

        if (hoverable == null) return false;

        return true;
    }

    private void HandleMouseButtonDownOnHoverable(ICursorHoverable hoverable, RaycastHit hit)
    {
        ICursorClickable clickable = hoverable as ICursorClickable;

        if (clickable != null) 
            clickable.OnCursorClick(hit);
    }
}
