using System.Collections.Generic;
using UnityEngine;

// Manages inventory items and handles adding and using them.
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // Singleton instance.

    private Dictionary<string, GameObject> inventory = new Dictionary<string, GameObject>();

    private void Awake()
    {
        // Ensure only one instance exists (singleton pattern).
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object when switching scenes.
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates on scene reload.
        }
    }

    // Add an item to the inventory if it’s not already there.
    public void AddItem(string itemName, GameObject item)
    {
        if (!inventory.ContainsKey(itemName))
        {
            inventory[itemName] = item;
            Debug.Log(itemName + " is toegevoegd aan de inventory.");
        }
    }

    // Use or store an item from the inventory.
    public void UseItem(string itemName)
    {
        if (inventory.ContainsKey(itemName))
        {
            GameObject item = inventory[itemName];

            bool isActive = item.activeSelf;

            if (isActive)
            {
                item.SetActive(false); // Hide the item.
                Debug.Log(itemName + " is weer opgeborgen.");
            }
            else
            {
                item.transform.position = PlayerPosition(); // Place in front of player.
                Debug.Log(itemName + " is uit de inventory gehaald.");
            }
        }
    }

    // Returns a position in front of the player’s camera.
    private Vector3 PlayerPosition()
    {
        return Camera.main.transform.position + Camera.main.transform.forward * 2;
    }
}
