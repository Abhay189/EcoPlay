using UnityEngine;

public class SpriteHoverChanger : MonoBehaviour
{
    public Sprite[] spriteArray; // Array of sprites to cycle through
    private int currentSpriteIndex = 0; // Index of the current sprite

    private bool isMouseOver = false;
    private float hoverTime = 2f; // Time in seconds to trigger the sprite change
    private float hoverTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (isMouseOver)
        {
            // Increment the hover timer while the mouse is over
            hoverTimer += Time.deltaTime;

            // Check if the hover time threshold is reached
            if (hoverTimer >= hoverTime & currentSpriteIndex < spriteArray.Length)
            {
                ChangeSprite();
                hoverTimer = 0f; // Reset the timer after changing the sprite
            }
        }
        else
        {
            // Reset the timer when the mouse is not over
            hoverTimer = 0f;
        }
    }

    void OnMouseOver()
    {
        // Called when the mouse is over the GameObject
        isMouseOver = true;
    }

    void OnMouseExit()
    {
        // Called when the mouse exits the GameObject
        isMouseOver = false;
    }

    void ChangeSprite()
    {
        // Get the SpriteRenderer component attached to the GameObject
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        // Check if a SpriteRenderer is attached
        if (spriteRenderer != null)
        {
            // Increment the index to get the next sprite
            currentSpriteIndex = (currentSpriteIndex + 1);

            // Change the sprite to the next one in the array
            spriteRenderer.sprite = spriteArray[currentSpriteIndex];
        }
        else
        {
            Debug.LogError("SpriteRenderer component not found on the GameObject.");
        }
    }
}