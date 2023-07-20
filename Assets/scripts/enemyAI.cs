using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;
    private float idleTimer;
    private float idleTime = 9.7f;
    public float alertRange = 10f;
    public float chaseRange = 5f;
    public float patrolRange = 15f;

    public enum MonsterState { Idle, Alert, Chase }
    public MonsterState currentState;

    private float movementFrequency = 0.5f; // How frequently the monster will apply erratic movements
    private float movementRange = 1.5f;     // The maximum distance the monster can offset its destination


    private float patrolTimer;
    private float patrolTime = 5f; // Adjust this to set how long the monster patrols in Alert state.
    private Vector3 randomPatrolPoint;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        currentState = MonsterState.Idle;
        idleTimer = idleTime;
    }


    private void Update()
    {
        Debug.Log(currentState);
        switch (currentState)
        {
            case MonsterState.Idle:
                UpdateIdleState();
                break;
            case MonsterState.Alert:
                UpdateAlertState();
                break;
            case MonsterState.Chase:
                UpdateChaseState();
                break;
            default:
                break;
        }
    }

    private void UpdateIdleState()
    {
        idleTimer -= Time.deltaTime;
        if (idleTimer <= 0f)
        {
            currentState = MonsterState.Alert;
            // Generate a random patrol point within the alertRange when transitioning to Alert state.
            randomPatrolPoint = GetRandomPatrolPoint();
            navMeshAgent.destination = randomPatrolPoint;
            //idleTimer = idleTime;
        }
        if (Vector3.Distance(transform.position, player.position) <= chaseRange)
        {
            currentState = MonsterState.Chase;
        }
    }

    private void UpdateAlertState()
    {
        if (Vector3.Distance(transform.position, player.position) <= chaseRange)
        {
            currentState = MonsterState.Chase;
        }
        else if (Vector3.Distance(transform.position, randomPatrolPoint) <= navMeshAgent.stoppingDistance)
        {
            // When reaching the patrol point, stand idle for a few seconds then generate a new random patrol point.
            idleTimer = idleTime;
            currentState = MonsterState.Idle;
            //randomPatrolPoint = GetRandomPatrolPoint();
            //navMeshAgent.destination = randomPatrolPoint;
        }
    }

    private void UpdateChaseState()
    {
        if (Vector3.Distance(transform.position, player.position) > alertRange)
        {
            currentState = MonsterState.Alert;
            randomPatrolPoint = GetRandomPatrolPoint();
            navMeshAgent.destination = randomPatrolPoint;
        }
        else
        {
            if (Random.value < movementFrequency)
            {
                AddRandomOffset();
            }
            navMeshAgent.destination = player.position;
        }
    }

    private void AddRandomOffset()
    {
        Vector3 randomOffset = new Vector3(Random.Range(-movementRange, movementRange), 0f, Random.Range(-movementRange, movementRange));
        navMeshAgent.destination += randomOffset;
    }

    private Vector3 GetRandomPatrolPoint()
    {
        // Generate a random point within the alertRange to patrol to.
        Vector3 randomDirection = Random.insideUnitSphere * patrolRange;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, alertRange, NavMesh.AllAreas);
        return hit.position;
    }
}
