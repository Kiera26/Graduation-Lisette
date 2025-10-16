using UnityEngine;

// Platform that moves side to side horizontally.
public class SidewaysMovingPlatform : MonoBehaviour
{
    public float moveDistance = 3f;  // How far the platform moves
    public float speed = 2f;         // How fast it moves

    private Vector3 startPosition;
    private bool movingRight = true;
    private bool isWaiting = false;
    private float waitTime = 2f;     // Time to pause at each end
    private float waitTimer = 0f;

    void Start()
    {
        startPosition = transform.position; // Save initial position
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
                movingRight = !movingRight; // Reverse direction
            }
            return; // Do not move while waiting
        }

        float step = speed * Time.deltaTime;
        Vector3 targetPosition = movingRight
            ? startPosition + Vector3.right * moveDistance
            : startPosition;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // If the platform reached its target, start waiting
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            isWaiting = true;
        }
    }
}
