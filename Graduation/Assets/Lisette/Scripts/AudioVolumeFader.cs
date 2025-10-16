using UnityEngine;

public class AudioVolumeFadeIn : MonoBehaviour
{
    public AudioSource audioSource;      // Assign in Inspector or auto-assign
    public float targetVolume = 5.0f;    // Max volume
    public float fadeDuration = 30.0f;    // Time to reach max volume

    private float timer = 0f;

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        audioSource.volume = 0f;          // Start silent
        audioSource.Play();               // Start playing
    }

    void Update()
    {
        if (audioSource.volume < targetVolume)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Clamp01(timer / fadeDuration) * targetVolume;
        }
    }
}
