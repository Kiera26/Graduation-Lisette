using UnityEngine;
using UnityEngine.UI; // of TMPro als je TextMeshPro gebruikt

public class WrongBookPrompt : MonoBehaviour
{
    public GameObject promptUI; // sleep hier je UI tekst naartoe
    private bool isPlayerInRange = false;

    void Start()
    {
        promptUI.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptUI.SetActive(true);
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptUI.SetActive(false);
            isPlayerInRange = false;
        }
    }
}
