using UnityEngine;

public class TestToTimry : MonoBehaviour
{
    public string TimryRoom; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            SceneFader fader = FindObjectOfType<SceneFader>();
            if (fader != null)
            {
                fader.FadeToScene(TimryRoom); 
            }
            else
            {
                Debug.LogWarning("SceneFader not found in the scene!");
            }
        }
    }
}
