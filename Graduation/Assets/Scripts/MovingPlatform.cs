using UnityEngine;

// Moves a platform up and down with wait time at each end.
public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 3f; // Distance the platform moves up and down.
    public float speed = 2f; // Speed at which the platform moves.
    private Vector3 startPosition; // The starting position of the platform.
    private bool movingUp = true; // Direction of movement (up or down).
    private bool isWaiting = false; // Indicates if the platform is waiting at the top/bottom.
    private float waitTime = 2f; // Time the platform waits before changing direction.
    private float waitTimer = 0f; // Timer to track wait time. 

    void Start()
    {
        startPosition = transform.position; // Initialize the start position.
    }

    void Update()
    {
        // Handle waiting at the top or bottom position.
        if (isWaiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                isWaiting = false;
                waitTimer = 0f;
                movingUp = !movingUp; // Reverse the movement direction after waiting.
            }
            return; // Do not move while waiting.
        }

        // Move the platform in the current direction.
        float step = speed * Time.deltaTime;
        Vector3 targetPosition = movingUp
            ? startPosition + Vector3.up * moveDistance // Move up.
            : startPosition; // Move back to start position.

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // Start waiting once the target position is reached.
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            isWaiting = true; // Start the waiting period at the top/bottom.
        }
    }
}
