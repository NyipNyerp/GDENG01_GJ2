using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ZombieController : MonoBehaviour
{
  
    public NavMeshAgent agent;

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerpos = player.transform.position;
        agent.SetDestination(playerpos);
         
        

    }
}