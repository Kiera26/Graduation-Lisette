using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float amplitude = 0.5f; // How high
    public float speed = 2f; // How fast

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        speed += Random.Range(-0.5f, 0.5f); //Small variation in speed
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}