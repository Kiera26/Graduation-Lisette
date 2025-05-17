using System.Collections;
using UnityEngine;
using TMPro; // Alleen als je TextMeshPro gebruikt

public class SubtitleManager : MonoBehaviour
{
    public TextMeshProUGUI subtitleText;
    [System.Serializable]
    public class SubtitleLine
    {
        public string text;
        public float duration;
    }

    public SubtitleLine[] subtitles;

    void Start()
    {
        StartCoroutine(PlaySubtitles());
    }

    IEnumerator PlaySubtitles()
    {
        foreach (var line in subtitles)
        {
            subtitleText.text = line.text;
            yield return new WaitForSeconds(line.duration);
        }

        subtitleText.text = ""; // Clear after done
    }
}
