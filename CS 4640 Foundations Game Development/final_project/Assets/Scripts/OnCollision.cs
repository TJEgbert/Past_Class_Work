using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        GameObject[] gameControllerObj = GameObject.FindGameObjectsWithTag("GameController");
        gameController = gameControllerObj[0].GetComponent<GameController>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        // If the game object is an EnemyProjectile
        if(gameObject.tag == "EnemyProjectile")
        {
            // If the enemy projectile hits either the player or a player projectile
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag== "PlayerProjectile")
            {
 
                Destroy(gameObject);
            }
        }
        
        // If the game object is a PlayerProjectile
        if (gameObject.tag == "PlayerProjectile")
        {
            // If it runs into anything expect the player
            if (collision.gameObject.tag != "Player")
            {
                // Remove bullet form global count
                gameController.NumberOfProjectileUpdate(-1);
                Destroy(gameObject);
            }

        }

        Destroy(gameObject);

    }
}
