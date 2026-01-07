using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextTriggerAvailable : MonoBehaviour
{


    [SerializeField] private Collider colliderToActivate1;
    [SerializeField] private Collider colliderToActivate2;
    [SerializeField] private Collider colliderToActivate3;
    [SerializeField] private Collider colliderToDeActivate4;
    [SerializeField] private Button RedButton;
    [SerializeField] private GameObject stairs;

    private bool interact;
    // depens on how many cilliders you want to activate






    void Start()
    {
        colliderToActivate1.enabled = false;
        colliderToActivate2.enabled = false;
        colliderToActivate3.enabled = false;
        RedButton.onClick.AddListener(OnButtonPressRed);
        colliderToDeActivate4.enabled = true;

        RedButton.onClick.AddListener(OnButtonPressRed);
    }



    void OnTriggerEnter(Collider other)
    {
        if (colliderToActivate1 != null)
        {
            colliderToActivate1.enabled = true;
            colliderToActivate2.enabled = true;
            colliderToActivate3.enabled = true;
            colliderToDeActivate4.enabled = false;





        }
    }

    public void OnButtonPressRed()
    {
        colliderToDeActivate4.enabled = false;

    }
}
