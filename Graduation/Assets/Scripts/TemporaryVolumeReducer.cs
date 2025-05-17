using System.Collections;
using UnityEngine;

public class TemporaryVolumeReducer : MonoBehaviour
{
    public AudioSource audioSource;       // Assign your AudioSource here
    public float reducedVolume = 0.2f;    // How quiet it gets temporarily
    public float duration = 20f;          // How long the volume stays low
    public float fadeDuration = 2f;       // How long it takes to restore the volume smoothly

    private float originalVolume;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        StartCoroutine(ReduceVolumeTemporarily());
    }

    IEnumerator ReduceVolumeTemporarily()
    {
        originalVolume = audioSource.volume;

        // Set volume lower
        audioSource.volume = reducedVolume;

        // Wait for duration
        yield return new WaitForSeconds(duration);

        // Smoothly restore volume
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            audioSource.volume = Mathf.Lerp(reducedVolume, originalVolume, elapsed / fadeDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure exact original volume at end
        audioSource.volume = originalVolume;
    }
}
