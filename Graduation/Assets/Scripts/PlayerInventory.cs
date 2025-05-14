using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Tracks how many tools the player has collected.
public class PlayerInventory : MonoBehaviour
{
    public int NumberOfTools { get; private set; } // Number of collected tools (read-only from outside).

    public UnityEvent<PlayerInventory> OnToolsCollected; // Event triggered when a tool is collected.

    // Called when the player collects a tool.
    public void ToolsCollected()
    {
        NumberOfTools++; // Increase tool count.
        OnToolsCollected.Invoke(this); // Trigger event to update UI or other systems.
    }
}
