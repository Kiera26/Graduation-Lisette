using UnityEngine;

public class AudioTrigger : MonoBehaviour
{

    [SerializeField] private AudioSource AudioTriggerAudio;

    private void OnTriggerEnter(Collider other)
    {

        AudioTriggerAudio.Play();




    }

}
