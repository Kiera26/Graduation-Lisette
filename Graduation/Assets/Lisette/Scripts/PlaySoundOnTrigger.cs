using UnityEngine;

public class PlaySoundOnceOnTrigger : MonoBehaviour
{
    public AudioClip soundClip;
    private AudioSource audioSource;
    private bool hasPlayed = false;  // checks wether the sounds is played already

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = soundClip;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.CompareTag("Player"))
        {
            audioSource.Play();
            hasPlayed = true;
        }
    }
}
