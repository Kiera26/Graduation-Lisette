using UnityEngine;

public class DelayedArrowBounce : MonoBehaviour
{
    public float delay = 60f; // Tijd tot activatie in seconden
    public float bounceHeight = 0.5f; // Hoogte van de op-en-neer beweging
    public float bounceSpeed = 2f; // Snelheid van de op-en-neer beweging

    private Vector3 initialPosition;
    private bool isActive = false;

    void Start()
    {
        initialPosition = transform.position;
        gameObject.SetActive(false); // Verberg pijl bij start
        Invoke("ActivateArrow", delay);
    }

    void ActivateArrow()
    {
        gameObject.SetActive(true);
        isActive = true;
    }

    void Update()
    {
        if (!isActive) return;

        float newY = initialPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }
}
