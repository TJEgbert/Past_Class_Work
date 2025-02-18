using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Used on the both types of projectiles
    private void OnCollisionEnter(Collision collision)
    {
        // If its a players projectile
        if (gameObject.tag == "PlayerProjectile")
        {
            // If it hits destroyable object destroys object and self
            if (collision.gameObject.tag == "CanBeDestroyed")
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }

            // If it hits enemy destroys object and self
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
        // If either project hits a wall destroys self
        if (collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
        // If enemy projectile hit an enemy it destroys itself
        if (gameObject.tag == "EnemyProjectile")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }
        }
    }

}
