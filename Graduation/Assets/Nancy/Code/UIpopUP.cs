using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIpopUP : MonoBehaviour
{

    [SerializeField]
    private Image _noteImage;
    private bool interact;


    // Start is called before the first frame update
    void Start()
    {
        _noteImage.enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _noteImage.enabled = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _noteImage.enabled = false;
        }
    }

    void Update(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))

            if (_noteImage.enabled == true)
            {


                _noteImage.enabled = false;
            }
            else

            {

                _noteImage.enabled = true;
            }

    }
}