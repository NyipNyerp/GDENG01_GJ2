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
    Collider collideObject;
    // Update is called once per frame
    void Update()
    {
        Vector3 currentTargetPos;
        if (zombieTarget.GetTarget() != null)
        {
            currentTargetPos = zombieTarget.GetTarget().transform.position;
            agent.SetDestination(currentTargetPos);
        }
        else
        {
            animator.SetBool("isAttacking", false);
            agent.SetDestination(this.gameObject.transform.position);
        }
        animator.SetFloat("Speed", agent.velocity.magnitude);

        if (animator.GetBool("isAttacking") && collideObject.gameObject.tag == "Player")
        {
            player.TakeDamage();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Civilian")
        {
            Debug.Log("Collided with " + collision.gameObject.name);
            animator.SetBool("isAttacking", true);

            if (collision.gameObject.tag == "Civilian")
            {
                CivilianNavigation civilian;
                collision.gameObject.TryGetComponent(out civilian);

                civilian.SetAlive(false);
            }
            GetCollider(collision);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Civilian")
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void GetCollider(Collider collision)
    {
        collideObject = collision;
    }
}