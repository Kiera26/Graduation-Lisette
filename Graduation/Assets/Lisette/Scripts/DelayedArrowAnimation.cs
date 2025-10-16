using UnityEngine;

// Shows the arrow after a delay and makes it bounce up and down.
public class DelayedArrowBounce : MonoBehaviour
{
    public float delay = 60f; // Time in seconds before arrow becomes visible.
    public float bounceHeight = 0.5f; // How high the arrow bounces.
    public float bounceSpeed = 2f; // How fast the arrow bounces.

    private Vector3 initialPosition; // Starting position of the arrow.
    private bool isActive = false; // True when arrow is active and bouncing.

    void Start()
    {
        initialPosition = transform.position;
        gameObject.SetActive(false); // Hide the arrow at the start.
        Invoke("ActivateArrow", delay); // Schedule activation after delay.
    }

    void ActivateArrow()
    {
        gameObject.SetActive(true); // Show the arrow.
        isActive = true;
    }

    void Update()
    {
        if (!isActive) return;

        // Move arrow up and down in a sine wave pattern.
        float newY = initialPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }
}
