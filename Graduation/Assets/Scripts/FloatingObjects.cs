using UnityEngine;

// Makes the object float up and down smoothly.
public class FloatingObject : MonoBehaviour
{
    public float amplitude = 0.5f; // Height of the floating motion.
    public float speed = 2f; // Speed of the floating motion.

    private Vector3 startPos; // Starting position of the object.

    void Start()
    {
        startPos = transform.position;
        speed += Random.Range(-0.5f, 0.5f); // Add slight variation to speed.
    }

    void Update()
    {
    // Move object up and down using a sine wave.
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}