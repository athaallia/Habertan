using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BabiAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] waypointTransform;
    private int waypointIndex;
    private Vector3 target;



    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }



    private void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            WaypointIndex();
            UpdateDestination();
        }
    }



    private void UpdateDestination()
    {
        target = waypointTransform[waypointIndex].position;
        agent.SetDestination(target);
    }



    private void WaypointIndex()
    {
        waypointIndex++;

        while (waypointIndex == waypointTransform.Length)
        {
            waypointIndex = 0;
        }
    }
}
