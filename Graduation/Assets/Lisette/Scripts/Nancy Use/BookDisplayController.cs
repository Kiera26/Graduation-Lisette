using UnityEngine;

public class BookDisplayController : MonoBehaviour
{
    public GameObject bookImage;   // Small icon that shows the book is in inventory
    public GameObject bookPanel;   // Full panel with video or text content

    private bool isVisible = false;  // Is the full panel currently visible?
    private bool hasBook = false;    // Has the book been picked up?

    void Start()
    {
        if (bookImage != null)
            bookImage.SetActive(false); // Hide icon by default

        if (bookPanel != null)
            bookPanel.SetActive(false); // Hide panel by default
    }

    void Update()
    {
        // If the player has picked up the book, allow toggling the panel with B
        if (hasBook && Input.GetKeyDown(KeyCode.B))
        {
            ToggleBookPanel();
        }
    }

    // Call this from BookPickup when the player picks up the book
    public void PickUpBook()
    {
        hasBook = true;

        if (bookImage != null)
            bookImage.SetActive(true); // Show the small icon

        Debug.Log("Book picked up! Icon shown. Press B to open the panel.");
    }

    // Toggle the full panel on/off
    public void ToggleBookPanel()
    {
        if (!hasBook || bookPanel == null) return;

        isVisible = !isVisible;
        bookPanel.SetActive(isVisible);
    }
}
