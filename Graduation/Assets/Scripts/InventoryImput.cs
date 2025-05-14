using UnityEngine;

// Handles input for using an item from the inventory.
public class InventoryInput : MonoBehaviour
{
    void Update()
    {
        // If B is pressed, use the item with ID "BOOK" via the InventoryManager.
        if (Input.GetKeyDown(KeyCode.B))
        {
            InventoryManager.Instance.UseItem("BOOK");
        }
    }
}
