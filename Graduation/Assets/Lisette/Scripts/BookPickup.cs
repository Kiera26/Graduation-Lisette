using UnityEngine;
using System.Collections;

public class BookPickup : MonoBehaviour
{
    public BookDisplayController bookDisplay;
    public PickupPrompt promptScript;
    public GameObject secondaryPromptUI;

    private bool hasPickedUp = false;
    private bool secondaryPromptVisible = false;

    void Start()
    {
        if (secondaryPromptUI != null)
            secondaryPromptUI.SetActive(false); // Ensure hidden at game start
    }


    void Update()
    {
        if (!hasPickedUp && promptScript != null && promptScript.isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            hasPickedUp = true;

            bookDisplay.PickUpBook();
            promptScript.HidePrompt();

            if (secondaryPromptUI != null)
            {
                secondaryPromptUI.SetActive(true);
                secondaryPromptVisible = true;
            }

            StartCoroutine(DisableAfterDelay(.1f));
        }

        // Hide secondary prompt if B is pressed
        if (secondaryPromptVisible && Input.GetKeyDown(KeyCode.B))
        {
            if (secondaryPromptUI != null)
                secondaryPromptUI.SetActive(false);

            secondaryPromptVisible = false;
        }
    }

    IEnumerator DisableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
