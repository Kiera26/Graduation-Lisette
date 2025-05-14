using UnityEngine;

// Handles picking up the book when the player is nearby and presses E. 
public class BookPickup : MonoBehaviour
{
    public BookDisplayController bookDisplay; // Reference to the book display controller.
    public PickupPrompt promptScript; // Reference to the prompt script (assign in Inspector).

    void Update()
    {
        // If player is in range and presses E
        if (promptScript != null && promptScript.isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            bookDisplay.PickUpBook(); // Notify the controller that the book is picked up.

            promptScript.HidePrompt(); // Hide the on-screen prompt.

            gameObject.SetActive(false); // Remove the book from the scene.
        }
    }
}
