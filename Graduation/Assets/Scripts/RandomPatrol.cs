using UnityEngine;
using UnityEngine.AI;

// Makes an NPC patrol randomly within a set radius using NavMesh.
public class RandomPatrol : MonoBehaviour
{
    public float patrolRadius = 20f;  // Patrol area radius.
    public float waitTime = 3f;       // Time to wait before moving again.

    private NavMeshAgent agent;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Get NavMeshAgent component.
        SetNewDestination(); // Start with a random destination.
    }

    void Update()
    {
        // If the agent reached destination, wait and then move again.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                SetNewDestination();
                timer = 0f;
            }
        }
    }

    // Pick a new random position on the NavMesh.
    void SetNewDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, 1))
        {
            agent.SetDestination(hit.position); // Move to new valid point.
        }
    }
}
