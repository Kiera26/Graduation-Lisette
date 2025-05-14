using UnityEngine;

// Controls the display of a book panel when the player has picked up the book.
public class BookDisplayController : MonoBehaviour
{
    public GameObject bookPanel; // UI panel to show the book.
    private bool isVisible = false; // Tracks if the panel is currently visible.
    private bool hasBook = false; // True after picking up the book.

    void Update()
    {
        // Toggle book panel when B is pressed and player has the book.
        if (Input.GetKeyDown(KeyCode.B) && hasBook)
        {
            isVisible = !isVisible;
            bookPanel.SetActive(isVisible);
        }
    }

    // Called when the player picks up the book.
    public void PickUpBook()
    {
        hasBook = true;
        Debug.Log("Boek opgepakt, je kunt het nu openen met B.");
    }
}
