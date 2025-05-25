using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoIntro : MonoBehaviour
{
    public VideoPlayer videoPlayer;        // Assign your VideoPlayer component here
    public VideoClip[] videoClips;         // Assign the array of video clips to play
    public string nextSceneName;           // Name of the next scene to load (must be in Build Settings)

    private int currentVideoIndex = 0;     // Keeps track of which video is currently playing

    void Start()
    {
        // Start playing the first video if any clips are assigned
        if (videoClips.Length > 0)
        {
            videoPlayer.clip = videoClips[currentVideoIndex];
            videoPlayer.Play();
        }
    }

    void Update()
    {
        // On pressing Space or left mouse button, move to the next video or load the next scene
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Debug.Log("Input received - moving to next video or scene");

            currentVideoIndex++;

            // If there are more videos left, play the next one
            if (currentVideoIndex < videoClips.Length)
            {
                videoPlayer.clip = videoClips[currentVideoIndex];
                videoPlayer.Play();
            }
            else
            {
                // If all videos are done, load the next scene
                Debug.Log("Last video finished - loading next scene");
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
