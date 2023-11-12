using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse click is over the object
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // Object is clicked
                isDragging = true;
                offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else
            {
                // Reset dragging if clicking on a different object or empty space
                isDragging = false;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Release the object
            isDragging = false;
        }

        if (isDragging)
        {
            // Move the object based on mouse position
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }
}