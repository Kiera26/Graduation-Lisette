using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

// Handles fading transitions between scenes.
public class SceneFader : MonoBehaviour
{
    public Image fadeImage;          // UI image used for fade effect.
    public float fadeDuration = 1f;  // Duration of fade in seconds.

    // Public method to start fade and load new scene.
    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeAndSwitchScene(sceneName));
    }

    private IEnumerator FadeAndSwitchScene(string sceneName)
    {
        yield return StartCoroutine(Fade(0f, 1f)); // Fade to black.
        SceneManager.LoadScene(sceneName);         // Load new scene.
    }

    // Handles the actual fade effect.
    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float time = 0f;
        Color color = fadeImage.color;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, time / fadeDuration);
            fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
    }

    private void Start()
    {
        // Fade in when the scene starts (from black to clear).
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1f);
        StartCoroutine(Fade(1f, 0f));
    }
}
