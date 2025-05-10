using UnityEngine;

public class ForwardBackwardMovingPlatform : MonoBehaviour
{
    public float moveDistance = 3f;  // Hoe ver het platform naar voren en achteren beweegt
    public float speed = 2f;         // Hoe snel het beweegt
    private Vector3 startPosition;
    private bool movingForward = true;
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
                movingForward = !movingForward; // Richting omkeren na wachten
            }
            return; // Tijdens wachten niets bewegen
        }

        float step = speed * Time.deltaTime;
        Vector3 targetPosition = movingForward
            ? startPosition + Vector3.forward * moveDistance
            : startPosition;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            isWaiting = true; // Start wachtperiode
        }
    }

    // Zorg dat de speler meebeweegt met het platform
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
