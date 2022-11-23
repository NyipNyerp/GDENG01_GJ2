using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ZombieController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement player;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerpos = player.transform.position;
        agent.SetDestination(playerpos);

        animator.SetFloat("Speed", agent.speed);

        if (animator.GetBool("isAttacking"))
        {
            player.TakeDamage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("isAttacking", true);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("isAttacking", false);
    }
}