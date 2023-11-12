using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Rigidbody2D rb;
    private Vector3 offset;

    void Start()
    {
        // Get the Rigidbody2D component (make sure the object has a Rigidbody2D attached)
        rb = GetComponent<Rigidbody2D>();
        // Ensure that gravity is enabled
        rb.gravityScale = 1f;
    }

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
        }

        if (!Input.GetMouseButton(0))
        {
            // If the mouse button is not held down, apply a downward force to simulate gravity
            rb.AddForce(Vector2.down * 10f);
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

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the falling object touches the ground
        Debug.Log("This is a log message 2");
        if (other.CompareTag("Ground"))
        {
            // Disable further falling by setting velocity to zero
            Debug.Log("This is a log message");
            rb.velocity = Vector2.zero;
            // Optionally, disable gravity
            rb.gravityScale = 0f;
        }
    }
}