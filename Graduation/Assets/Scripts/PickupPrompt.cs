using UnityEngine;

public class PickupPrompt : MonoBehaviour
{
    public GameObject promptUI; // Sleep hier de UI in
    [HideInInspector] public bool isPlayerInRange = false;

    void Start()
    {
        if (promptUI != null)
            promptUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && promptUI != null)
        {
            promptUI.SetActive(true);
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && promptUI != null)
        {
            promptUI.SetActive(false);
            isPlayerInRange = false;
        }
    }

    public void HidePrompt()
    {
        if (promptUI != null)
            promptUI.SetActive(false);
    }
}
