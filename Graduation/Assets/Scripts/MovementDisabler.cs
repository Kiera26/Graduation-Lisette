using System.Collections;
using UnityEngine;

public class MovementDisabler : MonoBehaviour
{
    public ThirdPersonMovement playerMovement;  // Reference to the player's movement script
    public float disableDuration = 5f;          // Time to disable movement (in seconds)

    void Start()
    {
        // Automatically disable movement on start.
        // Alternatively, you can call DisableMovementTemporarily() manually.
        StartCoroutine(DisableMovementTemporarily());
    }

    // Coroutine that disables player movement for a set duration
    public IEnumerator DisableMovementTemporarily()
    {
        if (playerMovement != null)
        {
            playerMovement.SetMovementEnabled(false);  // Disable movement
            yield return new WaitForSeconds(disableDuration);  // Wait for the specified time
            playerMovement.SetMovementEnabled(true);   // Re-enable movement
        }
    }
}
