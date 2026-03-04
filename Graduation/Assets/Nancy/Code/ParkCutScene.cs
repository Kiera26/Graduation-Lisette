using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ParkCutScene : MonoBehaviour
{

    [Header("Video")]
    [SerializeField] private VideoPlayer cutScenePark;
    [SerializeField] private Canvas cutSceneCanvas;


    [SerializeField] private string sceneName;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cutSceneCanvas.gameObject.SetActive(false);
        cutScenePark.enabled = false;

        cutScenePark.loopPointReached += OnVideoFinished;



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cutSceneCanvas.gameObject.SetActive(true);
            cutScenePark.enabled = true;
            cutScenePark.Play();


        }
       


    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("video is finished");
        SceneManager.LoadScene(sceneName);


    }
} 
