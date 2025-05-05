using UnityEngine;

public class BookDisplayController : MonoBehaviour
{
    public GameObject bookPanel;
    private bool isVisible = false;
    private bool hasBook = false; // <- boek nog niet opgepakt

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && hasBook)
        {
            isVisible = !isVisible;
            bookPanel.SetActive(isVisible);
        }
    }

    public void PickUpBook()
    {
        hasBook = true;
        Debug.Log("Boek opgepakt, je kunt het nu openen met B.");
    }
}
