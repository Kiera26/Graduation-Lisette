using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            InventoryManager.Instance.UseItem("BOOK");
        }
    }
}
