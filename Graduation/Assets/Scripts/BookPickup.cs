using UnityEngine;

public class BookPickup : MonoBehaviour
{
    private bool isPlayerInRange = false;
    public BookDisplayController bookDisplay; // sleep dit in de inspector

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            bookDisplay.PickUpBook();
            gameObject.SetActive(false); // boek fysiek weg
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
