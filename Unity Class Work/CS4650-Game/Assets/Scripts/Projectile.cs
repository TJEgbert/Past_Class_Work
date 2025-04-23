using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float damageNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 4.0f);
        damageNum = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        {
            EnemyScript enemyHit = collision.gameObject.GetComponent<EnemyScript>();

            if (enemyHit != null)
            {
                enemyHit.TakeDamage(damageNum);
            }

            // verify the object hit isn't the enemy projectile
			EnemyProjectile projectileHit = collision.gameObject.GetComponent<EnemyProjectile>();
            if (projectileHit == null)
            {
                // if it isn't, destroy it
				Destroy(gameObject);
			}
        }
    }

    public void IncreaseDamage(float dmg)
    {
		damageNum += dmg;
    }

    public void ResetDamage()
    {
		damageNum = 1.0f;
    }
}
