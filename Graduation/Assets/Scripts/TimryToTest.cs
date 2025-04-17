using UnityEngine;

public class TimryToTest : MonoBehaviour
{
    public string TestScene; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            SceneFader fader = FindObjectOfType<SceneFader>();
            if (fader != null)
            {
                fader.FadeToScene(TestScene); 
            }
            else
            {
                Debug.LogWarning("SceneFader not found in the scene!");
            }
        }
    }
}
