using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class MultiChoice : MonoBehaviour
{
    [Header("Video")]
    [SerializeField] private VideoPlayer cutScene;
    [SerializeField] private Canvas cutSceneCanvas;

    [Header("UI")]
    [SerializeField] private Canvas promptCanvas;
    [SerializeField] private Canvas brokenScreenCanvas;
    [SerializeField] private Canvas secondBrokenScreenCanvas;
    [SerializeField] private Canvas negativeFeedback;
    [SerializeField] private Canvas positiveFeedback;

    [Header("Buttons")]
    [SerializeField] private Button sitButton;
    [SerializeField] private Button notSitButton;
    [SerializeField] private Button slamDoorButton;
    [SerializeField] private Button notSlamDoorButton;
    [SerializeField] private Button washFaceButton;
    [SerializeField] private Button notWashFaceButton;
    [SerializeField] private Button spamButton;
    [SerializeField] private Button notSpamButton;
    [SerializeField] private Button restartButton;

    [Header("Audio")]
    [SerializeField] private AudioSource breakingAudio;
    [SerializeField] private AudioSource angryAudio;

    [Header("Triggers")]
    [SerializeField] private GameObject doorTrigger;
    [SerializeField] private GameObject sinkTrigger;
    [SerializeField] private GameObject elevatorTrigger;
    [SerializeField] private GameObject stairsTrigger;
    [SerializeField] private GameObject takingElevatorTrigger;

    private bool uiLockedForever = false;
    private bool uiCurrentlyOpen = false;

    private void Start()
    {
        Debug.Log("MultiChoice started");

        promptCanvas.gameObject.SetActive(false);
        cutSceneCanvas.gameObject.SetActive(false);
        brokenScreenCanvas.enabled = false;
        secondBrokenScreenCanvas.gameObject.SetActive(false);
        negativeFeedback.gameObject.SetActive(false);
        positiveFeedback.gameObject.SetActive(false);

        cutScene.enabled = false;

        sitButton.onClick.AddListener(SitButtonPressed);
        notSitButton.onClick.AddListener(ClosePrompt);
        slamDoorButton.onClick.AddListener(SlamDoorPressed);
        notSlamDoorButton.onClick.AddListener(ClosePrompt);
        washFaceButton.onClick.AddListener(WashFacePressed);
        notWashFaceButton.onClick.AddListener(WashFacePressed);
        spamButton.onClick.AddListener(SpamPressed);
        notSpamButton.onClick.AddListener(NotSpamPressed);
        restartButton.onClick.AddListener(RestartButtonPressed);

        cutScene.loopPointReached += OnVideoFinished;

        doorTrigger.SetActive(false);
        sinkTrigger.SetActive(false);
        elevatorTrigger.SetActive(false);
        stairsTrigger.SetActive(true);
        takingElevatorTrigger.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);
        Debug.Log("Showing prompt canvas");

        if (!other.CompareTag("Player") || uiLockedForever || uiCurrentlyOpen)
            return;

        promptCanvas.gameObject.SetActive(true);
        uiCurrentlyOpen = true;

        EventSystem.current.SetSelectedGameObject(null);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        promptCanvas.gameObject.SetActive(false);
        uiCurrentlyOpen = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // ---------------- BUTTON ACTIONS ----------------

    private void SitButtonPressed()
    {
        Debug.Log("sit button pressed");
        promptCanvas.gameObject.SetActive(false);
        cutSceneCanvas.gameObject.SetActive(true);
        cutScene.enabled = true;
        cutScene.Play();

        uiLockedForever = true;
    }

    private void ClosePrompt()
    {
        promptCanvas.gameObject.SetActive(false);
        uiCurrentlyOpen = false;
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("video is finished");

        angryAudio.Play();
        brokenScreenCanvas.enabled = true;

        cutSceneCanvas.gameObject.SetActive(false);
        cutScene.enabled = false;
        doorTrigger.SetActive(true);
        Cursor.visible = false;

        uiLockedForever = true;

    }

    private void SlamDoorPressed()
    {
        breakingAudio.Play();
        secondBrokenScreenCanvas.gameObject.SetActive(true);
        sinkTrigger.SetActive(true);

        uiLockedForever = true;
    }

    private void WashFacePressed()
    {
        brokenScreenCanvas.enabled = true;
        elevatorTrigger.SetActive(true);

        uiLockedForever = true;
    }

    private void SpamPressed()
    {
        negativeFeedback.gameObject.SetActive(true);
        stairsTrigger.SetActive(false);

        uiLockedForever = true;
    }

    private void NotSpamPressed()
    {
        positiveFeedback.gameObject.SetActive(true);
        takingElevatorTrigger.SetActive(true);

        uiLockedForever = true;
    }

    private void RestartButtonPressed()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}