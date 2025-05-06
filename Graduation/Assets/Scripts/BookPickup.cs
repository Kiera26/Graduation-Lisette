using UnityEngine;

public class BookPickup : MonoBehaviour
{
    public BookDisplayController bookDisplay;
    public PickupPrompt promptScript; // sleep hier het PickupPrompt script in

    void Update()
    {
        if (promptScript != null && promptScript.isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            bookDisplay.PickUpBook();

            // Verberg prompt via het script
            promptScript.HidePrompt();

            // Boek uitzetten
            gameObject.SetActive(false);
        }
    }
}
