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
    [SerializeField] private Button SitButton;
    [SerializeField] private Button NotSitButton;
    [SerializeField] private Button GreenButton;
    [SerializeField] private Button RedButton;
    [SerializeField] private Canvas brokenScreenCanvas;
    [SerializeField] private Canvas secondBrokenScreenCanvas;
    [SerializeField] private Canvas thirdBrokenScreenCanvas;


    void Start()
    {
        videoPlayer.enabled = false;
        myCanvas.enabled = false;
        videoCanvas.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        brokenScreenCanvas.enabled = false;
        secondBrokenScreenCanvas.enabled = false;
        thirdBrokenScreenCanvas.enabled = false;

        videoPlayer.loopPointReached += OnVideoFinished;

        SitButton.onClick.AddListener(OnButtonPressSit);
        NotSitButton.onClick.AddListener(OnButtonPressNotSit);

        RedButton.onClick.AddListener(OnButtonPressRed);
        GreenButton.onClick.AddListener(OnButtonPressGreen);

        // Subscribe to the video end event
       

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

    public void OnButtonPressSit()
    {
        // makes a video play, deactivates the script.
        videoCanvas.enabled = true;
        videoPlayer.enabled = true;
        videoPlayer.Play();

        myCanvas.enabled = false;


        //brokenScreenCanvas.enabled = true;
        //secondBrokenScreenCanvas.enabled = false;
      





        

    }

    public void OnButtonPressNotSit()
    {
        myCanvas.enabled = false;
        brokenScreenCanvas.enabled = false;
        secondBrokenScreenCanvas.enabled = false;
        thirdBrokenScreenCanvas.enabled = false;

    }
    // right now it extchanges the broken screen
    public void OnButtonPressGreen()
    {
        myCanvas.enabled = false;

        if (thirdBrokenScreenCanvas.enabled == true)
        {
            thirdBrokenScreenCanvas.enabled = false;
            secondBrokenScreenCanvas.enabled = true;
            brokenScreenCanvas.enabled = true;
        }
        //else if (thirdBrokenScreenCanvas.enabled = false)
       // {
        //    brokenScreenCanvas.enabled = true;
       //     secondBrokenScreenCanvas.enabled = true;
       //     thirdBrokenScreenCanvas.enabled = false;
       // }
        else if (secondBrokenScreenCanvas.enabled == true)
        {
            thirdBrokenScreenCanvas.enabled = false;
            secondBrokenScreenCanvas.enabled = false;
            brokenScreenCanvas.enabled = true;

        }
        else if (brokenScreenCanvas.enabled == true)
        {
            brokenScreenCanvas.enabled = false;
            secondBrokenScreenCanvas.enabled = false;
            thirdBrokenScreenCanvas.enabled = false;

        }


    }

    public void OnButtonPressRed()
    {
        myCanvas.enabled = false;

        if (brokenScreenCanvas.enabled = false)
        {
            brokenScreenCanvas.enabled = true;
            secondBrokenScreenCanvas.enabled = false;
        }

        else if (brokenScreenCanvas.enabled == true)
        {
            
            secondBrokenScreenCanvas.enabled = true;
            thirdBrokenScreenCanvas.enabled = false;

        }
        else
        {
            brokenScreenCanvas.enabled = true;
            secondBrokenScreenCanvas.enabled = true;
            thirdBrokenScreenCanvas.enabled = true;
        }


    }

    // This will be called when the video finishes
    private void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("Video finished event fired!");

        videoCanvas.enabled = false;
        videoPlayer.enabled = false;
    
        // optional: disable video player
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        myCanvas.enabled = false;

        //brokenScreenCanvas.enabled = true;


        if (brokenScreenCanvas.enabled = false)
        {

            brokenScreenCanvas.enabled = true;
            secondBrokenScreenCanvas.enabled = true;
        }
        else 
        {
            brokenScreenCanvas.enabled = true;
            secondBrokenScreenCanvas.enabled = false;
        }

        //brokenScreenCanvas.enabled = false;



        //}
    }

    private void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        videoPlayer.loopPointReached -= OnVideoFinished;
        //this.enabled = false;

    }



}
