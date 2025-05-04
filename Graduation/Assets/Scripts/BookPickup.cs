using UnityEngine;

public class BookPickup : MonoBehaviour
{
    public string itemName = "BOOK";
    private bool isPlayerInRange = false;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            InventoryManager.Instance.AddItem(itemName, gameObject);
            gameObject.SetActive(false); // Verberg boek
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Druk op E om het boek op te pakken.");
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
