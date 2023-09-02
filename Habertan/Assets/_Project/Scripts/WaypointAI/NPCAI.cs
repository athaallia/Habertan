using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAI : MonoBehaviour
{
    private NavMeshAgent agent;
    
    public Transform[] waypointTransform;

    private int waypointIndex;
    
    private Vector3 target;

    private Coroutine moveCoroutine;

    public Animator m_Animator;



    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (moveCoroutine != null) moveCoroutine = null;
        moveCoroutine = StartCoroutine(UpdateDestination());
    }



    private void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            RandomizeWaypointIndex();
            Idle();
            if (moveCoroutine != null) moveCoroutine = null;
            moveCoroutine = StartCoroutine(UpdateDestination());
        }
    }



    private IEnumerator UpdateDestination()
    {
        target = waypointTransform[waypointIndex].position;
        yield return new WaitForSeconds(2f);
        agent.SetDestination(target);

        Walk();
    }



    private void RandomizeWaypointIndex()
    {
        int randomWaypointIndex = Random.Range(0, waypointTransform.Length);

        while (waypointIndex == randomWaypointIndex)
        {
            randomWaypointIndex = Random.Range(0, waypointTransform.Length);
        }

        waypointIndex = randomWaypointIndex;
    }



    public void Idle()
    {
        m_Animator.SetBool("Idle", true);
        m_Animator.SetBool("Walk", false);
    }



    public void Walk()
    {
        m_Animator.SetBool("Walk", true);
        m_Animator.SetBool("Idle", false);
    }
}
