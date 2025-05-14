using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Updates the UI text to show how many tools the player has.
public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI toolsText; // Reference to the TextMeshPro UI component.

    void Start()
    {
        toolsText = GetComponent<TextMeshProUGUI>(); // Get the text component on this object.
    }

    // Updates the UI with the current number of tools from the player's inventory.
    public void UpdateToolsText(PlayerInventory playerInventory)
    {
        toolsText.text = playerInventory.NumberOfTools.ToString();
    }
}
