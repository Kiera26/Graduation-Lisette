using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticalTools : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.ToolsCollected();
            transform.GetChild(0).gameObject.SetActive(false); 

        }
    }
}
