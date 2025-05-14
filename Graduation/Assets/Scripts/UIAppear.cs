using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIAppear : MonoBehaviour
{
    [SerializeField] private Image customImage; // UI image that will be shown
    private bool hasShownUI = false; // Prevent showing UI more than once

    private void Start()
    {
        if (customImage != null)
        {
            customImage.enabled = false; // Make sure the UI is hidden at the start
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasShownUI)
        {
            if (customImage != null)
            {
                customImage.enabled = true; // Show the UI when player enters trigger
                hasShownUI = true; // Only show once

                // Prevent any UI button from being auto-selected
                EventSystem.current.SetSelectedGameObject(null);
            }
        }
    }

    private void Update()
    {
        // If the UI is visible and the player presses 'R'
        if (customImage != null && customImage.enabled)
        {
            Debug.Log("Popup is visible");

            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("R key pressed");
                customImage.enabled = false; // Hide the UI
            }
        }
    }
}
