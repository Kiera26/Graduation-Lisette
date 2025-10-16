using UnityEngine;
using UnityEngine.AI;

public class RandomPatrol : MonoBehaviour
{
    public float patrolRadius = 20f;
    public float waitTime = 3f;
    public float stopDistanceFromPlayer = 3f;

    private NavMeshAgent agent;
    private float timer;
    private Transform player;
    private bool isPlayerNear = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        SetNewDestination();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        bool playerClose = distanceToPlayer <= stopDistanceFromPlayer;

        if (playerClose && !isPlayerNear)
        {
            StopWalking();
        }
        else if (!playerClose && isPlayerNear)
        {
            ResumeWalking();
        }

        isPlayerNear = playerClose;

        // Only patrol if player is NOT near
        if (!isPlayerNear && !agent.pathPending && agent.remainingDistance < 0.5f && !agent.isStopped)
        {
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                SetNewDestination();
                timer = 0f;
            }
        }
    }

    void StopWalking()
    {
        agent.isStopped = true;
        agent.ResetPath(); // Optional: stop mid-move
    }

    void ResumeWalking()
    {
        agent.isStopped = false;
        SetNewDestination(); // Resume patrol when player leaves
    }

    void SetNewDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}
