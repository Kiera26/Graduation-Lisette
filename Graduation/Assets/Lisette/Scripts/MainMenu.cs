using UnityEngine;
using UnityEngine.SceneManagement;

// Handles actions in the main menu like starting the game, opening credits, or quitting the game.
public class MainMenu : MonoBehaviour
{
    [Header("Scene Namen")]
    public string gameSceneName;         // Name of the scene to load for the game.
    public string creditsSceneName;      // Name of the scene for the credits.
    public string mainMenuSceneName;     // Name of the scene for the main menu.
    public string timryRoomSceneName;    // Name of the scene for Timry's room.
    public string citySceneName;         // Name of the city scene.
    public string bookstoreSceneName;    // Name of the bookstore scene.
    public string optionsSceneName;      // Name of the scene for the options menu.

    // Starts the game by loading the specified game scene.
    public void StartGame()
    {
        if (!string.IsNullOrEmpty(gameSceneName)) 
        {
            SceneManager.LoadScene(gameSceneName);
        }
        else
        {
            Debug.LogWarning("Game scene name is not set!");
        }
    }

    // Opens the credits scene.
    public void OpenCredits()
    {
        if (!string.IsNullOrEmpty(creditsSceneName))
        {
            SceneManager.LoadScene(creditsSceneName);
        }
        else
        {
            Debug.LogWarning("Credits scene name is not set!");
        }
    }

    // Quits the application.
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    // Returns to the main menu scene.
    public void ReturnToMainMenu()
    {
        if (!string.IsNullOrEmpty(mainMenuSceneName))
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }
        else
        {
            Debug.LogWarning("Main menu scene name is not set!");
        }
    }

    // Loads Timry's Room scene.
    public void GoToTimryRoom()
    {
        if (!string.IsNullOrEmpty(timryRoomSceneName))
        {
            SceneManager.LoadScene(timryRoomSceneName);
        }
        else
        {
            Debug.LogWarning("Timry Room scene name is not set!");
        }
    }

    // Loads the City scene.
    public void GoToCity()
    {
        if (!string.IsNullOrEmpty(citySceneName))
        {
            SceneManager.LoadScene(citySceneName);
        }
        else
        {
            Debug.LogWarning("City scene name is not set!");
        }
    }

    // Loads the Bookstore scene.
    public void GoToBookstore()
    {
        if (!string.IsNullOrEmpty(bookstoreSceneName))
        {
            SceneManager.LoadScene(bookstoreSceneName);
        }
        else
        {
            Debug.LogWarning("Bookstore scene name is not set!");
        }
    }

    // Loads the Options Menu scene.
    public void OpenOptions()
    {
        if (!string.IsNullOrEmpty(optionsSceneName))
        {
            SceneManager.LoadScene(optionsSceneName);
        }
        else
        {
            Debug.LogWarning("Options scene name is not set!");
        }
    }
}
