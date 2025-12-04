using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextpopUP : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _yourText;
    private bool interact;


    // Start is called before the first frame update
    void Start()
    {
        _yourText.enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _yourText.enabled = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _yourText.enabled = false;
        }
    }

   
}