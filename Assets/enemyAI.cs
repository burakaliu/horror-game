using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private GameObject target;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player"); // Replace "Player" with the appropriate tag or assign the target directly in the Inspector
    }

    private void Update()
    {
        if (target != null)
        {
            navMeshAgent.SetDestination(target.transform.position);
        }
    }
}
