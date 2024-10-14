using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    private Vector2 prevPos;
    private Vector2 offset;
    [SerializeField] private bool _clampToScreen = true;

    private Rect GetScreenBounds()
    {
        Camera camera = Camera.main;
        if (camera == null) return new Rect();

        Vector3 bottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));

        return new Rect(bottomLeft.x, bottomLeft.y, topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        prevPos = transform.position;

        // Calculate the offset between the mouse position and the object's position
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        mouseWorldPosition.z = 0; // Set z to 0 since we're in 2D

        offset = (Vector2)transform.position - (Vector2)mouseWorldPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        mouseWorldPosition.z = 0; // Set z to 0 since we're in 2D

        // Apply the offset to the mouse position
        Vector3 newPosition = mouseWorldPosition + (Vector3)offset;

        // Calculate the object's size based on its RectTransform (for UI) or Collider (for 2D)
        Vector2 objectSize = GetObjectSize();

        // Clamp the position within the screen bounds, taking the object's size into account
        if (_clampToScreen)
        {
            Rect screenBounds = GetScreenBounds();
            newPosition.x = Mathf.Clamp(newPosition.x, screenBounds.xMin + objectSize.x / 2, screenBounds.xMax - objectSize.x / 2);
            newPosition.y = Mathf.Clamp(newPosition.y, screenBounds.yMin + objectSize.y / 2, screenBounds.yMax - objectSize.y / 2);
        }

        transform.position = newPosition;
    }

    private Vector2 GetObjectSize()
    {
        // If the object has a RectTransform (for UI elements)
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            return rectTransform.sizeDelta * rectTransform.lossyScale;
        }

        // If the object has a Collider (for 2D elements)
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            Bounds bounds = collider.bounds;
            return new Vector2(bounds.size.x, bounds.size.y);
        }

        // Default to zero if no relevant components found
        return Vector2.zero;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Optional: Reset position or implement logic for what happens when drag ends
        // transform.position = prevPos;
    }

    public void OnDrop(PointerEventData eventData)
    {
        // Implement drop logic here if needed
    }
}
