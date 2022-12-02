using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ZombieController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private ZombieTargetting zombieTarget;

    // Update is called once per frame
    void Update()
    {
        //Vector3 playerpos = player.transform.position;

        Vector3 currentTargetPos;
        if (zombieTarget.target != null)
        {
            currentTargetPos = zombieTarget.target.transform.position;
            agent.SetDestination(currentTargetPos);
        }
        else
        {
            agent.SetDestination(agent.gameObject.transform.position);
        }
        animator.SetFloat("Speed", agent.velocity.magnitude);

        if (animator.GetBool("isAttacking"))
        {
            player.TakeDamage();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "FPSPlayer" || collision.gameObject.name == "Civilian")
        {
            Debug.Log("Collided with " + collision.gameObject.name);
            animator.SetBool("isAttacking", true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "FPSPlayer" || collision.gameObject.name == "CivilianAsian")
        {
            animator.SetBool("isAttacking", false);
        }
    }
}