using UnityEngine;

public class SidewaysMovingPlatform : MonoBehaviour
{
    public float moveDistance = 3f;      // Hoe ver de balk heen en weer beweegt
    public float speed = 2f;             // Beweegsnelheid
    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;

        if (movingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition + Vector3.right * moveDistance, step);

            if (Vector3.Distance(transform.position, startPosition + Vector3.right * moveDistance) < 0.01f)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, step);

            if (Vector3.Distance(transform.position, startPosition) < 0.01f)
            {
                movingRight = true;
            }
        }
    }
}
