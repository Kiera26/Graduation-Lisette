using UnityEngine;
using UnityEngine.SceneManagement;

// Handles actions in the main menu like starting the game, opening credits, or quitting the game.
public class MainMenu : MonoBehaviour
{
    [Header("Scene Namen")]
    public string gameSceneName; // Name of the scene to load for the game.
    public string creditsSceneName; // Name of the scene for the credits.

    // Starts the game by loading the specified game scene.
    public void StartGame()
    {
        if (!string.IsNullOrEmpty(gameSceneName)) 
        {
            SceneManager.LoadScene(gameSceneName); // Load the game scene.
        }
        else
        {
            Debug.LogWarning("Game scene name is not set!"); // Warning if the scene name is not set.
        }
    }

    // Opens the credits scene.
    public void OpenCredits()
    {
        if (!string.IsNullOrEmpty(creditsSceneName))
        {
            SceneManager.LoadScene(creditsSceneName); // Load the credits scene.
        }
        else
        {
            Debug.LogWarning("Credits scene name is not set!"); // Warning if the scene name is not set.
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game"); // Log a message before quitting.
        Application.Quit(); // Quit the application.
    }
}
