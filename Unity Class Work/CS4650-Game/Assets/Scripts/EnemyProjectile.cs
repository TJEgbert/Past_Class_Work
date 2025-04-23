using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    [SerializeField] int damage = 1;
    [SerializeField] float travelTime = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, travelTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }

		// verify the object hit isn't the player projectile
		Projectile projectileHit = collision.gameObject.GetComponent<Projectile>();
		if (projectileHit == null)
		{
			// if it isn't, destroy it
			Destroy(gameObject);
		}
	}
}
