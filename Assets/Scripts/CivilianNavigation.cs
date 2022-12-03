using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CivilianNavigation : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject destination;
    [SerializeField] private bool isAlive = true;

    void Start()
    {
        animator.SetBool("isAlive", true);
    }

    void Update()
    {
        Vector3 destinationPos = destination.transform.position;
        agent.SetDestination(destinationPos);

        animator.SetFloat("Speed", agent.velocity.magnitude);

        if (!isAlive)
        {
            agent.isStopped = true;
            animator.SetBool("isAlive", false);
        }
    }

    public bool CheckAlive()
    {
        return isAlive;
    }

    public void SetAlive(bool status)
    {
        isAlive = status;
    }
}
