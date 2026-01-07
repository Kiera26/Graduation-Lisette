using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;


public class SceneAvailable : MonoBehaviour
{

    [SerializeField] private Button ElevatorGreenButton;
    [SerializeField] public BoxCollider colliderToEnable;

    void Start()
    {

        colliderToEnable.enabled = false;
        ElevatorGreenButton.onClick.AddListener(OnButtonPressGreen);
    }

    public void OnButtonPressGreen()
    {
        colliderToEnable.enabled = true;

    }

}