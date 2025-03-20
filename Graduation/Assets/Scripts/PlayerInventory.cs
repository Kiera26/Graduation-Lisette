using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfTools { get; private set; }

    public UnityEvent<PlayerInventory> OnToolsCollected;

    public void ToolsCollected()
    {
        NumberOfTools++;
        OnToolsCollected.Invoke(this);
    }
}
