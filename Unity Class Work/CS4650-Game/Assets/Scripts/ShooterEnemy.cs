using UnityEngine;
using System.Collections;
using System.IO;
using static UnityEngine.GraphicsBuffer;
using System.Runtime.CompilerServices;

public class ShooterEnemy : MonoBehaviour
{

    // Used to track the player
    GameObject player;

    // Used in the projectile spawning
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject spawnLocation;
    [SerializeField] float projectileSpeed;
    [SerializeField] float maxFireRateTime = 3.0f;
    [SerializeField] float minFireRateTime = 0.5f;
    private float fireRate;

    // Sets the attack range of the enemy
    [SerializeField] CircleCollider2D aggroRange;

    // Tracks if the enemy has fired
    private bool fired = false;

    // Used to track if the player is in trigger area
    private bool playerEntered = false;

    private AudioSource soundPlayer;
    [SerializeField] AudioClip projectileSoundEffect;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fireRate = Random.Range(minFireRateTime, maxFireRateTime);
        player = GameObject.FindGameObjectWithTag("Player");
        soundPlayer = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the is active and is trigger range
        if (playerEntered)
        {
            if (!fired)
            {
                // Fires projectile and sets up a cooldown
                spawnProjectile();
                fired = true;
                soundPlayer.PlayOneShot(projectileSoundEffect, 0.5f);
                StartCoroutine(BulletFired());
            }
            RotateEnemy();
        }
    }

    // Spawns a projectile and fires it towards the player
    private void spawnProjectile()
    {
        GameObject instFoam = Instantiate(projectile, spawnLocation.transform.position, spawnLocation.transform.rotation);
        Rigidbody2D instRB = instFoam.GetComponent<Rigidbody2D>();
        Vector2 force = new Vector2(spawnLocation.transform.position.x, spawnLocation.transform.position.y);
        instRB.AddForce(spawnLocation.transform.up * projectileSpeed);
    }

    // Starts bullet cool down
    IEnumerator BulletFired()
    {

        yield return new WaitForSeconds(fireRate);
        fired = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerEntered = false;
        }
    }

    /// <summary>
    /// Gets the players position and calculates the amount of rotation needed to face the player
    /// </summary>
    private void RotateEnemy()
    {
        Vector3 targetPos = player.transform.position;
        Vector3 thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
