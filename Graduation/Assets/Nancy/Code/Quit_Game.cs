using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Quit_Game : MonoBehaviour
{


    [SerializeField] public Button Quit_Button;


    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Quit_Button.onClick.AddListener(QuitGame);
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit Game"); // Log the quit action.
        Application.Quit(); // Quit the application.
    }

}
