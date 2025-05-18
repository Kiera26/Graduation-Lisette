using UnityEngine;

// Moves a platform forward and backward with wait time at each end.
// Also makes the player stick to the platform while standing on it.
public class ForwardBackwardMovingPlatform : MonoBehaviour
{
    public float moveDistance = 3f; // Distance to move forward.
    public float speed = 2f; // Movement speed.
    private Vector3 startPosition; // Initial position of the platform.
    private bool movingForward = true;
    private bool isWaiting = false;
    private float waitTime = 2f; // Wait time before changing direction.
    private float waitTimer = 0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Handle waiting at end positions.
        if (isWaiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                isWaiting = false;
                waitTimer = 0f;
                movingForward = !movingForward; // Change direction.
            }
            return; 
        }

        // Move platform in the current direction.
        float step = speed * Time.deltaTime;
        Vector3 targetPosition = movingForward
            ? startPosition + Vector3.forward * moveDistance
            : startPosition;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // Start waiting once the target position is reached.
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            isWaiting = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered platform");
            other.transform.SetParent(transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited platform");
            other.transform.SetParent(null);
        }
    }

}
