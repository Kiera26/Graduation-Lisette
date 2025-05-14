using UnityEngine;

public class TimryToTest : MonoBehaviour
{
    public string TestScene; // Name of the scene to load (set in the Inspector)

    // Triggered when another collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the object is the player
        {
            SceneFader fader = FindObjectOfType<SceneFader>(); // Find the fader in the scene
            if (fader != null)
            {
                fader.FadeToScene(TestScene); // Start fading and load the new scene
            }
            else
            {
                Debug.LogWarning("SceneFader not found in the scene!"); // Help debug if the fader is missing
            }
        }
    }
}
