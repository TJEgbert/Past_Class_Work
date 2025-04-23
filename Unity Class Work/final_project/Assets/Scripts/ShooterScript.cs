using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder;

public class ShooterScript : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject spawnLocation;
    [SerializeField] GameObject deathFlames;

    [SerializeField] float projectileSpeed = 10;
    [SerializeField] float spawnSpeed = 5.0f;

    private Animator m_Animator;
    private GameController gameController;

    private bool firing = false;
    private bool fired = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        GameObject[] gameControllerObj = GameObject.FindGameObjectsWithTag("GameController");
        gameController = gameControllerObj[0].GetComponent<GameController>();
    }


    // Update is called once per frame
    void Update()
    {
        // Makes sure the shooter is firing, ready to fire again, and if the player is alive
        if (firing && !fired && gameController.IsPlayerAlive())
        {
            m_Animator.SetTrigger("Fire");
            spawnProjectile();
            fired = true;
            StartCoroutine(BulletFired());
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        // The player enters aggro range
        if (other.tag == "Player")
        {
            firing = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If hit with a projectile
        if(collision.gameObject.tag == "PlayerProjectile")
        {
            firing = false;
            m_Animator.SetTrigger("Death");
            Instantiate(deathFlames, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject, 1.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If player exits the aggro range
        if (other.tag == "Player")
        {
            firing = false;
        }
        else if (other.tag == "EnemyProjectile")
        {
            // If the enemies projectile is out of shooting range
            Destroy(other.gameObject);
        }
    }

    //  Resets fire is the enemy can shoot again
    IEnumerator BulletFired()
    {
        yield return new WaitForSeconds(spawnSpeed);
        fired = false;
    }

    //  Shoots a projectile towards the player
    private void spawnProjectile()
    {
        GameObject instFoam = Instantiate(projectile, spawnLocation.transform.position, spawnLocation.transform.rotation);
        Rigidbody instRB = instFoam.GetComponent<Rigidbody>();
        instRB.AddForce(spawnLocation.transform.up * projectileSpeed * -1);
    }
}
