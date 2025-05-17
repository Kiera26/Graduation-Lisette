using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageSubtitleManager : MonoBehaviour
{
    [System.Serializable]
    public class Slide
    {
        public Sprite image;
        public string text;
        public float duration;
    }

    public Image displayImage;
    public TextMeshProUGUI subtitleText;
    public Slide[] slides;

    void Start()
    {
        StartCoroutine(PlaySlides());
    }

    IEnumerator PlaySlides()
    {
        foreach (var slide in slides)
        {
            displayImage.sprite = slide.image;
            subtitleText.text = slide.text;
            yield return new WaitForSeconds(slide.duration);
        }

        // Clear after done
        displayImage.sprite = null;
        subtitleText.text = "";
    }
}
