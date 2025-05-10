using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 3f;      // Hoe ver de balk op en neer gaat
    public float speed = 2f;             // Hoe snel de balk beweegt
    private Vector3 startPosition;
    private bool movingUp = true;
    private bool isWaiting = false;
    private float waitTime = 2f;
    private float waitTimer = 0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (isWaiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                isWaiting = false;
                waitTimer = 0f;
                movingUp = !movingUp; // Richting omkeren na wachten
            }
            return; // Tijdens wachten niet bewegen
        }

        float step = speed * Time.deltaTime;
        Vector3 targetPosition = movingUp
            ? startPosition + Vector3.up * moveDistance
            : startPosition;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            isWaiting = true; // Start wachtperiode
        }
    }
}
