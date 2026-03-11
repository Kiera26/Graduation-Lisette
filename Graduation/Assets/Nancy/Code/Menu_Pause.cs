using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu_Pause : MonoBehaviour
{

    private bool isPaused = false;


    [Header("Buttons")]
    [SerializeField] public Button Continue_Button;
    [SerializeField] public Button Sounds_Button;
    [SerializeField] public Button Credits_Button;
    [SerializeField] public Button BackMenu1_Button;
    [SerializeField] public Button BackMenu2_Button;
    [SerializeField] public Button Quit_Button;


    [Header("UI")]
    [SerializeField] private Canvas pauseMenuCanvas;
    [SerializeField] private Canvas soundsCanvas;
    [SerializeField] private Canvas creditsCanvas;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenuCanvas.gameObject.SetActive(false);


        soundsCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(false);

        Continue_Button.onClick.AddListener(ContinueGame);
        Sounds_Button.onClick.AddListener(Sounds);
        Credits_Button.onClick.AddListener(Credits);
        BackMenu1_Button.onClick.AddListener(BackMenu1);
        BackMenu2_Button.onClick.AddListener(BackMenu2);
        Quit_Button.onClick.AddListener(Quit);



    }

    void Update()
    {
        // Toggle pause state when the P or Escape key is pressed.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ContinueGame(); // Resume the game if it's paused.
            }
            else
            {
                Pause(); // Pause the game if it's not paused.
            }
        }
    }
    public void Pause()
    {
        pauseMenuCanvas.gameObject.SetActive(true); // Show the pause menu. 
        Time.timeScale = 0f; // Freeze the game.
        isPaused = true;

        // Show and unlock the cursor.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void ContinueGame()
    {

        pauseMenuCanvas.gameObject.SetActive(false); // Hide the pause menu.
        Time.timeScale = 1f; // Resume normal game speed.
        isPaused = false;

        // Hide and lock the cursor.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;



    }
    private void Sounds()
    {
        pauseMenuCanvas.gameObject.SetActive(false);
        soundsCanvas.gameObject.SetActive(true);


    }

    private void Credits()
    {

        pauseMenuCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(true);



    }

    private void BackMenu1()
    {
        soundsCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(false);
        pauseMenuCanvas.gameObject.SetActive(true);


    }
    private void BackMenu2()
    {
        soundsCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(false);
        pauseMenuCanvas.gameObject.SetActive(true);


    }

    private void Quit()
    {
        Application.Quit();

    }
}
