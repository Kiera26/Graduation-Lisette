using UnityEngine;

public class SidewaysMovingPlatform : MonoBehaviour
{
    public float moveDistance = 3f;      // Hoe ver de balk heen en weer beweegt
    public float speed = 2f;             // Beweegsnelheid
    private Vector3 startPosition;
    private bool movingRight = true;
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
                movingRight = !movingRight; // Richting omkeren na het wachten
            }
            return; // Stop met bewegen tijdens het wachten
        }

        float step = speed * Time.deltaTime;
        Vector3 targetPosition = movingRight
            ? startPosition + Vector3.right * moveDistance
            : startPosition;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            isWaiting = true; // Start de pauze
        }
    }
}
