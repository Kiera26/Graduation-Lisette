using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Updates the minimap's position to follow the player's movement.
public class Minimap : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform.

    // Update the minimap's position to match the player's X and Z position, keeping the same Y position.
    void LateUpdate ()
    {
        Vector3 newPosition = player.position; 
        newPosition.y = transform.position.y; // Keep the minimap at a constant height.
        transform.position = newPosition; // Update minimap position.
    }

}
