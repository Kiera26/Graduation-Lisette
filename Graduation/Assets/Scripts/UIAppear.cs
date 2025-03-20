using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAppear : MonoBehaviour
{
    [SerializeField] private Image customImage;
    private bool hasShownUI = false; // Flag to check if UI has been shown

    void OnTriggerEnter(Collider other)
    {
        // Show the UI only the first time the player enters the trigger
        if (other.CompareTag("Player") && !hasShownUI)
        {
            customImage.enabled = true;
            hasShownUI = true; // Mark that the UI has been shown
        }
    }

    void Update()
    {
        // Hide the UI when the Esc key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            customImage.enabled = false;
        }
    }
}