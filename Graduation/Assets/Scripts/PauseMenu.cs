using UnityEngine;
using UnityEngine.SceneManagement;

// Manages the pause menu functionality in the game.
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the pause menu UI.
    private bool isPaused = false; // Flag to check if the game is paused.

    [Header("Scene Instellingen")]
    public string mainMenuSceneName = "MainMenu";  // Name of the main menu scene (set in Inspector).

    void Update()
    {
        // Toggle pause state when the P key is pressed.
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume(); // Resume the game if it's paused.
            }
            else
            {
                Pause(); // Pause the game if it's not paused.
            }
        }
    }

    // Resume the game by hiding the pause menu and restoring game time.
    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Hide the pause menu.
        Time.timeScale = 1f; // Resume normal game speed.
        isPaused = false;

        // Hide and lock the cursor.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Pause the game by showing the pause menu and freezing game time.
    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Show the pause menu. 
        Time.timeScale = 0f; // Freeze the game.
        isPaused = true;

        // Show and unlock the cursor.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Load the main menu scene and reset time scale.
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Resume normal game speed.

        // Show and unlock the cursor before switching scenes.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene(mainMenuSceneName); // Load the main menu scene.
    }

    // Quit the game and log the action.
    public void QuitGame()
    {
        Debug.Log("Quit Game"); // Log the quit action.
        Application.Quit(); // Quit the application.
    }
}
