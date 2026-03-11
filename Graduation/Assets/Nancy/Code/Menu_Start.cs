using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu_Start : MonoBehaviour
{

    [Header("Buttons")]
    [SerializeField] public Button StartGame_Button;
    [SerializeField] public Button Sounds_Button;
    [SerializeField] public Button Credits_Button;
    [SerializeField] public Button MainMenu1_Button;
    [SerializeField] public Button MainMenu2_Button;
    [SerializeField] public Button Quit_Button;


    [Header("UI")]
    [SerializeField] private Canvas MainMenuCanvas;
    [SerializeField] private Canvas soundsCanvas;
    [SerializeField] private Canvas creditsCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MainMenuCanvas.gameObject.SetActive(true);


        soundsCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(false);

        StartGame_Button.onClick.AddListener(StartGame);
        Sounds_Button.onClick.AddListener(Sounds);
        Credits_Button.onClick.AddListener(Credits);
        MainMenu1_Button.onClick.AddListener(MainMenu1);
        MainMenu2_Button.onClick.AddListener(MainMenu2);
        Quit_Button.onClick.AddListener(Quit);



    }

    private void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StadVanVanAllesEnNogwat");




    }
    private void Sounds()
    {
        MainMenuCanvas.gameObject.SetActive(false);
        soundsCanvas.gameObject.SetActive(true);
        

    }

    private void Credits()
    {

        MainMenuCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(true);



    }

    private void MainMenu1()
    {
        soundsCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(false);
        MainMenuCanvas.gameObject.SetActive(true);


    }
    private void MainMenu2()
    {
        soundsCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(false);
        MainMenuCanvas.gameObject.SetActive(true);


    }
    private void Quit()
    {
        Application.Quit();

    }
}
