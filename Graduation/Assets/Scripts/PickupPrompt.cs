using UnityEngine;

// Handles showing and hiding a UI prompt when the player is near a pickup item.
public class PickupPrompt : MonoBehaviour
{
    public GameObject promptUI;         // First UI prompt.
    public GameObject secondaryPromptUI; // Second UI popup or action after interaction.
    [HideInInspector] public bool isPlayerInRange = false; // True when player is near.
    private bool hasInteracted = false; // Tracks whether the player has interacted.

    void Start()
    {
        if (promptUI != null) promptUI.SetActive(false);
        if (secondaryPromptUI != null) secondaryPromptUI.SetActive(false);
    }

    void Update()
    {
        // Wait for player input while in range and prompt is active
        if (isPlayerInRange && !hasInteracted && Input.GetKeyDown(KeyCode.E))
        {
            // Hide first prompt and show second UI (or do something else)
            if (promptUI != null) promptUI.SetActive(false);
            if (secondaryPromptUI != null) secondaryPromptUI.SetActive(true);
            hasInteracted = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && promptUI != null)
        {
            promptUI.SetActive(true);
            isPlayerInRange = true;
            hasInteracted = false; // Reset interaction when entering
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (promptUI != null) promptUI.SetActive(false);
            if (secondaryPromptUI != null) secondaryPromptUI.SetActive(false);
            isPlayerInRange = false;
            hasInteracted = false;
        }
    }

    public void HidePrompt()
    {
        if (promptUI != null) promptUI.SetActive(false);
        if (secondaryPromptUI != null) secondaryPromptUI.SetActive(false);
    }
}
