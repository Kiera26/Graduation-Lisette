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
    [SerializeField] private Canvas doorPromptCanvas;
    [SerializeField] private Canvas sinkPromptCanvas;
    [SerializeField] private Canvas elevatorPromptCanvas;
    [SerializeField] private Canvas coutchPromptCanvas;

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
    [SerializeField] private Button continueButton;

    [Header("Audio")]
    [SerializeField] private AudioSource breakingAudio;
    [SerializeField] private AudioSource angryAudio;
    [SerializeField] private AudioSource doorAudio;
    [SerializeField] private AudioSource SinkAudio;
    [SerializeField] private AudioSource ElevatorAudio;

    [Header("Triggers")]
    [SerializeField] private GameObject doorTrigger;
    [SerializeField] private GameObject sinkTrigger;
    [SerializeField] private GameObject elevatorTrigger;
    [SerializeField] private GameObject stairsTrigger;
    [SerializeField] private GameObject takingElevatorTrigger;

    [Header("Animations")]
    [SerializeField] private Animator DoorAnimator;
    [SerializeField] private Animator PaintingAnimator;
    [SerializeField] private Animator VaseAnimator;

    private bool uiLockedForever = false;
    private bool uiCurrentlyOpen = false;

    private bool couchDone;
    private bool doorDone;
    private bool sinkDone;
    private bool elevatorDone;

    

    private void Start()
    {
        Debug.Log("MultiChoice started");

        GetComponent<ThirdPersonMovement>().enabled = true;


        promptCanvas.gameObject.SetActive(false);
        doorPromptCanvas.gameObject.SetActive(false);
        sinkPromptCanvas.gameObject.SetActive(false);
        coutchPromptCanvas.gameObject.SetActive(false);
        elevatorPromptCanvas.gameObject.SetActive(false);
        cutSceneCanvas.gameObject.SetActive(false);
        brokenScreenCanvas.enabled = false;
        secondBrokenScreenCanvas.gameObject.SetActive(false);
        negativeFeedback.gameObject.SetActive(false);
        positiveFeedback.gameObject.SetActive(false);

        

        cutScene.enabled = false;

        sitButton.onClick.AddListener(SitButtonPressed);
        notSitButton.onClick.AddListener(ClosePrompt);
        slamDoorButton.onClick.AddListener(SlamDoorPressed);
        notSlamDoorButton.onClick.AddListener(NotSlamPrompt);
        washFaceButton.onClick.AddListener(WashFacePressed);
        notWashFaceButton.onClick.AddListener(NotWashFacePressed);
        spamButton.onClick.AddListener(SpamPressed);
        notSpamButton.onClick.AddListener(NotSpamPressed);
        restartButton.onClick.AddListener(RestartButtonPressed);
        continueButton.onClick.AddListener(ContinueButtonPressed);

        cutScene.loopPointReached += OnVideoFinished;

        doorTrigger.SetActive(false);
        sinkTrigger.SetActive(false);
        elevatorTrigger.SetActive(false);
        stairsTrigger.SetActive(true);
        takingElevatorTrigger.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        DoorAnimator.GetComponent<Animator>();
        PaintingAnimator.GetComponent<Animator>();
        VaseAnimator.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered: " + other.name);
        Debug.Log("Showing prompt canvas");

        //if (!other.CompareTag("Player") || uiLockedForever || uiCurrentlyOpen)
        //return;
        

        // ---- Coutch TRIGGER ----
        if (other.CompareTag("CoutchTrigger") && !couchDone)
        {
            ShowCoutchUI();
            return;
        }



        // ---- DOOR TRIGGER ----
        if (other.CompareTag("DoorTrigger") && !doorDone)
        {
            ShowDoorUI();
            return;
        }



        // ---- SINK TRIGGER ----
        if (other.CompareTag("SinkTrigger") && !sinkDone)
        {
            ShowSinkUI();
            return;
        }

        // ---- SINK TRIGGER ----
        if (other.CompareTag("ElevatorTrigger") && !elevatorDone)
        {
            ShowElevatorUI();
            return;
        }

        //promptCanvas.gameObject.SetActive(true);
        uiCurrentlyOpen = true;

        EventSystem.current.SetSelectedGameObject(null);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (other.CompareTag("CoutchTrigger"))
        {
            coutchPromptCanvas.gameObject.SetActive(false);
            return;
        }

        if (other.CompareTag("DoorTrigger"))
        {
            doorPromptCanvas.gameObject.SetActive(false);
            return;
        }

        if (other.CompareTag("SinkTrigger"))
        {
            sinkPromptCanvas.gameObject.SetActive(false);
            return;
        }

        if (other.CompareTag("ElevatorTrigger"))
        {
            elevatorPromptCanvas.gameObject.SetActive(false);
            return;
        }

        promptCanvas.gameObject.SetActive(false);
        uiCurrentlyOpen = false;
        coutchPromptCanvas.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // ---------------- BUTTON ACTIONS ----------------
    private void ShowCoutchUI()
    {
        Debug.Log("Entered coutch trigger");

        GetComponent<ThirdPersonMovement>().enabled = false;

        coutchPromptCanvas.gameObject.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void SitButtonPressed()
    {
        Debug.Log("sit button pressed");

        
        promptCanvas.gameObject.SetActive(false);
        cutSceneCanvas.gameObject.SetActive(true);
        cutScene.enabled = true;
        cutScene.Play();

        uiLockedForever = true;

        couchDone = true;
    }

    private void ClosePrompt()
    {
        GetComponent<ThirdPersonMovement>().enabled = true;
        promptCanvas.gameObject.SetActive(false);
        uiCurrentlyOpen = false;
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("video is finished");

        GetComponent<ThirdPersonMovement>().enabled = true;

        breakingAudio.Play();
        angryAudio.Play();
        brokenScreenCanvas.enabled = true;
        secondBrokenScreenCanvas.enabled = false;

        cutSceneCanvas.gameObject.SetActive(false);
        cutScene.enabled = false;
        doorTrigger.SetActive(true);
        Cursor.visible = false;

        uiLockedForever = true;

        

    }

   
    private void ShowDoorUI()
    {
        Debug.Log("Entered door trigger");

        GetComponent<ThirdPersonMovement>().enabled = false;

        doorPromptCanvas.gameObject.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void ShowSinkUI()
    {
        Debug.Log("Entered sink trigger");

        GetComponent<ThirdPersonMovement>().enabled = false;

        sinkPromptCanvas.gameObject.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void ShowElevatorUI()
    {
        Debug.Log("Entered elevator trigger");

        GetComponent<ThirdPersonMovement>().enabled = false;

        elevatorPromptCanvas.gameObject.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    private void SlamDoorPressed()
    {
        Debug.Log("slam door pressed");

        GetComponent<ThirdPersonMovement>().enabled = true;

        DoorAnimator.Play("DoorSlam");
        PaintingAnimator.Play("Painting fall");
        VaseAnimator.Play("ObjectsFallen");

        breakingAudio.Play();
        


        if (brokenScreenCanvas.enabled == true)
        {
            secondBrokenScreenCanvas.gameObject.SetActive(true);
            secondBrokenScreenCanvas.enabled = true;
        }

        sinkTrigger.SetActive(true);
        doorPromptCanvas.gameObject.SetActive(false);

        uiLockedForever = true;

        sinkTrigger.SetActive(true);

        doorDone = true;
        doorAudio.Play(); 
    }

    private void NotSlamPrompt()
    {
        Debug.Log("not slam pressed");

        GetComponent<ThirdPersonMovement>().enabled = true;

        brokenScreenCanvas.enabled = false;
        sinkTrigger.SetActive(true);
        doorPromptCanvas.gameObject.SetActive(false);

        uiLockedForever = true;

        sinkTrigger.SetActive(true);

        doorDone = true;

    }

    private void WashFacePressed()
    {
        GetComponent<ThirdPersonMovement>().enabled = true;

        if (brokenScreenCanvas.enabled == true)
        {

            brokenScreenCanvas.enabled = false;
        }
           


        else if (secondBrokenScreenCanvas.enabled == true)
        {
           
            secondBrokenScreenCanvas.enabled = false;
            brokenScreenCanvas.enabled = true;

        }
        sinkPromptCanvas.gameObject.SetActive(false);
        elevatorTrigger.SetActive(true);

        uiLockedForever = true;

        SinkAudio.Play();

        sinkDone = true;
    }

    private void NotWashFacePressed()
    {

        GetComponent<ThirdPersonMovement>().enabled = true;

        if (brokenScreenCanvas.enabled = true)
        {

            secondBrokenScreenCanvas.enabled = true;
        }




        breakingAudio.Play();
        elevatorTrigger.SetActive(true);
        sinkPromptCanvas.gameObject.SetActive(false);
        uiLockedForever = true;

        sinkDone = true;
    }

    private void SpamPressed()
    {

        Debug.Log("spamming the button pressed");

        GetComponent<ThirdPersonMovement>().enabled = true;

        negativeFeedback.gameObject.SetActive(true);
        stairsTrigger.SetActive(false);
        elevatorPromptCanvas.gameObject.SetActive(false);
        uiLockedForever = true;

        elevatorDone = true;
    }

    private void NotSpamPressed()
    {
        Debug.Log("not spamming button pressed");

        GetComponent<ThirdPersonMovement>().enabled = true;

        if (brokenScreenCanvas.enabled == false)
        {
            positiveFeedback.gameObject.SetActive(true);
            takingElevatorTrigger.SetActive(true);
        }
        
        else if (brokenScreenCanvas.enabled == true)
        {
            negativeFeedback.gameObject.SetActive(true);

        }



        elevatorPromptCanvas.gameObject.SetActive(false);
        uiLockedForever = true;

        ElevatorAudio.Play();

        elevatorDone = true;
    }

    private void RestartButtonPressed()

    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    private void ContinueButtonPressed()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ParkToGo");
           
    }
}