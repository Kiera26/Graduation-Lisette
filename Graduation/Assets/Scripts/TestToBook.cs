using UnityEngine;

public class TestToBook : MonoBehaviour
{
    public string BookStore; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            SceneFader fader = FindObjectOfType<SceneFader>();
            if (fader != null)
            {
                fader.FadeToScene(BookStore); 
            }
            else
            {
                Debug.LogWarning("SceneFader not found in the scene!");
            }
        }
    }
}
