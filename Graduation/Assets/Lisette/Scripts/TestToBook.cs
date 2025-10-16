using UnityEngine;

// Triggers a scene change when the player enters the trigger zone.
public class TestToBook : MonoBehaviour
{
    public string BookStore; // Name of the scene to load

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering is the player
        if (other.CompareTag("Player")) 
        {
            // Try to find a SceneFader in the scene
            SceneFader fader = FindObjectOfType<SceneFader>();
            if (fader != null)
            {
                // Use SceneFader to load the scene with a fade effect
                fader.FadeToScene(BookStore); 
            }
            else
            {
                Debug.LogWarning("SceneFader not found in the scene!");
            }
        }
    }
}
