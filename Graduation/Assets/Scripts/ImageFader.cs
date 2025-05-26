using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFader : MonoBehaviour
{
    public CanvasGroup imageGroup;       // The image's CanvasGroup
    public float delay = 10f;            // Delay before fade starts
    public float fadeDuration = 1.5f;    // How long the fade-in/out takes
    public float visibleDuration = 4f;   // How long the image stays fully visible

    void Start()
    {
        // Start fully invisible
        imageGroup.alpha = 0f;
        imageGroup.interactable = false;
        imageGroup.blocksRaycasts = false;

        // Begin the whole sequence
        StartCoroutine(FadeSequence());
    }

    IEnumerator FadeSequence()
    {
        // Wait before starting fade in
        yield return new WaitForSeconds(delay);

        // --- Fade In ---
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            imageGroup.alpha = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        imageGroup.alpha = 1f;
        imageGroup.interactable = true;
        imageGroup.blocksRaycasts = true;

        // --- Stay visible ---
        yield return new WaitForSeconds(visibleDuration);

        // --- Fade Out ---
        elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            imageGroup.alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        imageGroup.alpha = 0f;
        imageGroup.interactable = false;
        imageGroup.blocksRaycasts = false;
    }
}
