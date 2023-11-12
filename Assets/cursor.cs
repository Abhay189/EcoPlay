using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    public Texture2D customCursor; // Drag and drop your custom cursor sprite here

    void Start()
    {
        // Call a method to change the cursor when the player enters the game
        SetCustomCursor();
    }

    void SetCustomCursor()
    {
        // Check if the custom cursor is assigned
        if (customCursor != null)
        {
            // Set the cursor to the custom texture
            Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Debug.LogError("Custom cursor texture is not assigned!");
        }
    }
}