using UnityEngine;

[RequireComponent(typeof(Light))]
public class SpookyFlicker : MonoBehaviour
{
    private Light flickerLight;

    [Header("Flicker Settings")]
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.5f;
    public float flickerSpeed = 0.1f; // time between flickers

    private void Start()
    {
        flickerLight = GetComponent<Light>();
        StartCoroutine(Flicker());
    }

    private System.Collections.IEnumerator Flicker()
    {
        while (true)
        {
            flickerLight.intensity = Random.Range(minIntensity, maxIntensity);

            // Random chance to "spike" the light off momentarily
            if (Random.value < 0.1f)
            {
                flickerLight.enabled = false;
                yield return new WaitForSeconds(Random.Range(0.05f, 0.2f));
                flickerLight.enabled = true;
            }

            yield return new WaitForSeconds(Random.Range(flickerSpeed * 0.5f, flickerSpeed * 1.5f));
        }
    }
}
