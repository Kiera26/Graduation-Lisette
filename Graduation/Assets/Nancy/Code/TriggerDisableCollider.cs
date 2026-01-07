using UnityEngine;

public class TriggerDisableCollider : MonoBehaviour
{
    public BoxCollider colliderToDisable;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);

        colliderToDisable.enabled = false;
    }
}