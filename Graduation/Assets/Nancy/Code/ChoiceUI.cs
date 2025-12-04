using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class ChoiceUI : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private Canvas myCanvas;
    [SerializeField] private Canvas videoCanvas;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    void Start()
    {
        videoPlayer.enabled = false;
        myCanvas.enabled = false;
        videoCanvas.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yesButton.onClick.AddListener(OnButtonPressYes);
        noButton.onClick.AddListener(OnButtonPressNo);

        // Subscribe to the video end event
        videoPlayer.loopPointReached += OnVideoFinished;
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            myCanvas.enabled = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            myCanvas.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void OnButtonPressYes()
    {
        videoCanvas.enabled = true;
        videoPlayer.enabled = true;
        videoPlayer.Play();
        this.enabled = false; // optional if you don’t need this script active during video
        
    }

    public void OnButtonPressNo()
    {
        myCanvas.enabled = false;
    }

    // This will be called when the video finishes
    private void OnVideoFinished(VideoPlayer vp)
    {
        videoCanvas.enabled = false; // hide the video canvas
        videoPlayer.enabled = false;  // optional: disable video player
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        myCanvas.enabled = false;


    }

    private void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        videoPlayer.loopPointReached -= OnVideoFinished;
        
    }
}
