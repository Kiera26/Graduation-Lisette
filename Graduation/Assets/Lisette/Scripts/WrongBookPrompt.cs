using UnityEngine;
using UnityEngine.UI; // Or use TMPro if you're using TextMeshPro

public class WrongBookPrompt : MonoBehaviour
{
    public GameObject promptUI; // Drag your UI text GameObject here
    private bool isPlayerInRange = false;

    void Start()
    {
        // Hide the prompt UI at the start
        promptUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        // Show prompt when the player enters the trigger
        if (other.CompareTag("Player"))
        {
            promptUI.SetActive(true);
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Hide prompt when the player exits the trigger
        if (other.CompareTag("Player"))
        {
            promptUI.SetActive(false);
            isPlayerInRange = false;
        }
    }
}

