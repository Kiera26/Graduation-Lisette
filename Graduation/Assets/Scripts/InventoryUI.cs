using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI toolsText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        toolsText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateToolsText(PlayerInventory playerInventory)
    {
        toolsText.text = playerInventory.NumberOfTools.ToString();
    }
}
