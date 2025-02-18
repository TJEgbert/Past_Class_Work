using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // Used to store a reference to the player
    public Transform player;

    // Sets get the navMeshAgent component
    private NavMeshAgent navMeshAgent;
    //Gets the enemy starting position 
    private Vector3 startingPosition;
    [SerializeField] NavMeshSurface surface; 

    // Start is called before the first frame update
    void Start()
    {
        // Gets the start position of the enemy
        navMeshAgent = GetComponent<NavMeshAgent>();
        startingPosition = navMeshAgent.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Follows the player if they can and if not returns to the the starting position
            var path = new NavMeshPath();
            if (navMeshAgent.CalculatePath(player.position, path))
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(player.position);

            }
            else
            {
                navMeshAgent.SetDestination(startingPosition);
            }
            
        }
    }
}
