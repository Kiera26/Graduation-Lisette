using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 3f;      // Hoe ver de balk op en neer gaat
    public float speed = 2f;             // Hoe snel de balk beweegt
    private Vector3 startPosition;
    private bool movingUp = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;

        if (movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition + Vector3.up * moveDistance, step);

            if (Vector3.Distance(transform.position, startPosition + Vector3.up * moveDistance) < 0.01f)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, step);

            if (Vector3.Distance(transform.position, startPosition) < 0.01f)
            {
                movingUp = true;
            }
        }
    }
}
