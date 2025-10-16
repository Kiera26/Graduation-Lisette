using UnityEngine;

// Loads a new scene when the player enters a trigger zone
public class TestToTimry : MonoBehaviour
{
    public string TimryRoom; // Name of the scene to load

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player triggered the collider
        if (other.CompareTag("Player")) 
        {
            // Find the SceneFader in the scene
            SceneFader fader = FindObjectOfType<SceneFader>();
            if (fader != null)
            {
                // Start fading to the target scene
                fader.FadeToScene(TimryRoom); 
            }
            else
            {
                Debug.LogWarning("SceneFader not found in the scene!");
            }
        }
    }
}
