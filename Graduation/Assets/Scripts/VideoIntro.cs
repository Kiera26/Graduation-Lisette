using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoIntro : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component
    public string nextSceneName; // Name of the scene to load after video ends

    void Start()
    {
        // Subscribe to the video end event
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(VideoPlayer vp)
    {
        Debug.Log("Video finished playing");
        SceneManager.LoadScene(nextSceneName); // Load the next scene
    }
}
