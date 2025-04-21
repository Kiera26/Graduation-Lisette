using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAppear : MonoBehaviour
{
    [SerializeField] private Image customImage;
    private bool hasShownUI = false;

    private void Start()
    {
        if (customImage != null)
        {
            customImage.enabled = false; // Zorg dat het begin uit staat
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
            }
        }
    }

    private void Update()
    {
        if (customImage != null && customImage.enabled && Input.GetKeyDown(KeyCode.R))
        {
            customImage.enabled = false;
        }
    }

}
