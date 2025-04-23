using NavMeshPlus.Components;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

//using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // Used to store a reference to the player
    Transform player;

    // Sets get the navMeshAgent component
    private NavMeshAgent agent;

    [SerializeField] GameObject spawnLocation;

    private bool warpped = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // Gets the start position of the enemy
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!warpped)
        {
            if (agent.Warp(spawnLocation.transform.position))
            {
                warpped = true;
            }
        }
        NavMeshPath path = new NavMeshPath();
        if(player != null)
        {
            if (agent.CalculatePath(player.position, path))
            {
                agent.isStopped = false;
                agent.SetDestination(player.position);
            }
            else
            {
                agent.isStopped = true;
            }
        }

    }
}
