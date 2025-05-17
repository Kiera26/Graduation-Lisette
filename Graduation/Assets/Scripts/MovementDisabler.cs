using System.Collections;
using UnityEngine;

public class MovementDisabler : MonoBehaviour
{
    public ThirdPersonMovement playerMovement;
    public float disableDuration = 5f;

    void Start()
    {
        // Roep automatisch uit bij start, of noem DisableMovement() handmatig
        StartCoroutine(DisableMovementTemporarily());
    }

    public IEnumerator DisableMovementTemporarily()
    {
        if (playerMovement != null)
        {
            playerMovement.SetMovementEnabled(false);
            yield return new WaitForSeconds(disableDuration);
            playerMovement.SetMovementEnabled(true);
        }
    }
}
