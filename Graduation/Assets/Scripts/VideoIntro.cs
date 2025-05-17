using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoIntro : MonoBehaviour
{
    public VideoPlayer videoPlayer;        // Sleep hier je VideoPlayer in
    public VideoClip[] videoClips;         // Sleep hier je video's in
    public string nextSceneName;           // Naam van de volgende scene (in Build Settings)

    private int currentVideoIndex = 0;

    void Start()
    {
        if (videoClips.Length > 0)
        {
            videoPlayer.clip = videoClips[currentVideoIndex];
            videoPlayer.Play();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spatie gedrukt - volgende video of scene");

            currentVideoIndex++;

            if (currentVideoIndex < videoClips.Length)
            {
                videoPlayer.clip = videoClips[currentVideoIndex];
                videoPlayer.Play();
            }
            else
            {
                Debug.Log("Laatste video bekeken - scene wordt geladen");
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
