using UnityEngine;

// Handles showing and hiding a UI prompt when the player is near a pickup item.
public class PickupPrompt : MonoBehaviour
{
    public GameObject promptUI; // UI element shown when the player is in range.
    [HideInInspector] public bool isPlayerInRange = false; // True when player is near.

    void Start()
    {
        if (promptUI != null)
            promptUI.SetActive(false); // Hide the prompt at start.
    }

    void OnTriggerEnter(Collider other)
    {
        // Show prompt when the player enters the trigger area.
        if (other.CompareTag("Player") && promptUI != null)
        {
            promptUI.SetActive(true);
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Hide prompt when the player leaves the trigger area.
        if (other.CompareTag("Player") && promptUI != null)
        {
            promptUI.SetActive(false);
            isPlayerInRange = false;
        }
    }

    // Can be called to manually hide the prompt (e.g. after pickup).
    public void HidePrompt()
    {
        if (promptUI != null)
            promptUI.SetActive(false);
    }
}
