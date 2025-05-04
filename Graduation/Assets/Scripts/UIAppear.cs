using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIAppear : MonoBehaviour
{
    [SerializeField] private Image customImage;
    private bool hasShownUI = false;

    private void Start()
    {
        if (customImage != null)
        {
            customImage.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasShownUI)
        {
            if (customImage != null)
            {
                customImage.enabled = true;
                hasShownUI = true;

                // Zorg dat geen UI-element automatisch geselecteerd is
                EventSystem.current.SetSelectedGameObject(null);
            }
        }
    }

    private void Update()
    {
        //Debug.Log("Update loopt");

        if (customImage != null && customImage.enabled)
        {
            Debug.Log("Popup is zichtbaar");

            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("R ingedrukt!");
                customImage.enabled = false;
            }
        }
    }
}
