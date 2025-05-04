using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private Dictionary<string, GameObject> inventory = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // << Deze regel zorgt dat hij blijft bestaan
        }
        else
        {
            Destroy(gameObject); // voorkom duplicates bij terugkeren naar eerdere scenes
        }
    }

    public void AddItem(string itemName, GameObject item)
    {
        if (!inventory.ContainsKey(itemName))
        {
            inventory[itemName] = item;
            Debug.Log(itemName + " is toegevoegd aan de inventory.");
        }
    }

    public void UseItem(string itemName)
    {
        if (inventory.ContainsKey(itemName))
        {
            GameObject item = inventory[itemName];

            bool isActive = item.activeSelf;

            if (isActive)
            {
                item.SetActive(false); // Verberg het boek
                Debug.Log(itemName + " is weer opgeborgen.");
            }
            else
            {
                item.SetActive(true); // Toon het boek
                item.transform.position = PlayerPosition();
                Debug.Log(itemName + " is uit de inventory gehaald.");
            }
        }
    }


    private Vector3 PlayerPosition()
    {
        return Camera.main.transform.position + Camera.main.transform.forward * 2;
    }
}
