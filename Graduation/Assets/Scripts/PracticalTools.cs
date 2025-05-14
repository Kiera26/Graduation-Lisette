using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Detects when the player collects a tool and updates inventory.
public class PracticalTools : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.ToolsCollected(); // Add tool to inventory.
            transform.GetChild(0).gameObject.SetActive(false); // Hide tool visually.
        }
    }
}
