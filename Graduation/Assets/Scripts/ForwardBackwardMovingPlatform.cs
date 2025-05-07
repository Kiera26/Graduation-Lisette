using UnityEngine;

public class ForwardBackwardMovingPlatform : MonoBehaviour
{
    public float moveDistance = 3f;  // Hoe ver het platform naar voren en achteren beweegt
    public float speed = 2f;         // Hoe snel het beweegt
    private Vector3 startPosition;
    private bool movingForward = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;

        if (movingForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition + Vector3.forward * moveDistance, step);

            if (Vector3.Distance(transform.position, startPosition + Vector3.forward * moveDistance) < 0.01f)
            {
                movingForward = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, step);

            if (Vector3.Distance(transform.position, startPosition) < 0.01f)
            {
                movingForward = true;
            }
        }
    }
}
