using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered platform");
            other.transform.SetParent(transform.parent); // Parent = MovingPlatform
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited platform");
            other.transform.SetParent(null);
        }
    }
}
