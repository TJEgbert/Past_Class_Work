using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class ShooterEnemy : MonoBehaviour
{
    // Used to track the player
    [SerializeField] GameObject player;

    // Used in the projectile spawning
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject spawnLocation;
    [SerializeField] float projectileSpeed;

    // Sets the attack range of the enemy
    [SerializeField] SphereCollider aggroRange;

    // Tracks if the enemy has fired
    private bool fired = false;

    // Used to track if the player is in trigger area
    private bool playerEntered = false;

    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        // Checks if the is active and is trigger range
        if (player.activeSelf && playerEntered) 
        {
            if(!fired)
            {
                // Fires projectile and sets up a cooldown
                spawnProjectile();
                fired = true;
                StartCoroutine(BulletFired());
            }
            // tracks the player
            transform.LookAt(player.transform);
        }
    }

    // Spawns a projectile and fires it towards the player
    private void spawnProjectile()
    {
        GameObject instFoam = Instantiate(projectile, spawnLocation.transform.position, spawnLocation.transform.rotation);
        Rigidbody instRB = instFoam.GetComponent<Rigidbody>();
        instRB.AddForce(spawnLocation.transform.forward * projectileSpeed);
    }

    // Starts bullet cool down
    IEnumerator BulletFired() 
    {
        yield return new WaitForSeconds(1.0f);
        fired = false;
    }

    // Sets the player is in the firing range
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerEntered = true;
        }
      
    }

    // Player left the firing range
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerEntered = false;
        }
    }

}
