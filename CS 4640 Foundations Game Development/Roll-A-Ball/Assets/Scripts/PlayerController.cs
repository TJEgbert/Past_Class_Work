using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;
using UnityEngine.Pool;
using UnityEngine.UI;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // RigidBody of the player
    private Rigidbody rb;

    // Movement along X and Y axes
    private float movementX;
    private float movementY;

    // Used for the firing of the projectile
    private float counter;
    private bool gameStarted = false;
    [SerializeField] GameManager gameManager;
    [SerializeField] float firingRate = 1.0f;
    private bool firing = false;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject spawnLocation;
    [SerializeField] GameObject spawnRotation;
    [SerializeField] float projectileSpeed = 10.0f;
    [SerializeField] GameObject gun;

    // Players speed
    public float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the Rigidbody of the player
        rb = GetComponent<Rigidbody>();
        counter = firingRate;
    }

    private void Update()
    {
        if (gameStarted) 
        {
            // Play starts to fire if left mouse button is down
            if (Input.GetMouseButtonDown(0))
            {
                firing = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                // Stops firing when the user let goes of left moue button
                firing = false;
            }

            if (firing)
            {
                // Handles the rappid fire of the gun
                if (counter >= firingRate)
                {
                    spawnProjectile();
                    counter = 0;
                }
                counter += Time.deltaTime;
            }
        } 
    }

    // Gets called once per fixed frame-rate frame
    private void FixedUpdate()
    {
        if (gameObject) 
        {
            // Create the 3D movement vector using movementX and movementY
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            if (Mathf.Abs(rb.velocity.z) < 30.0f && Mathf.Abs(rb.velocity.x) < 30.0f)
            {
                rb.AddForce(movement * speed);
            }
        }

    }

    void OnMove(InputValue movementValue)
    {
        if(gameStarted)
        {
            // Converts Input into a Vector2 input
            Vector2 movementVector = movementValue.Get<Vector2>();

            // Store the X and Y components of the movement
            movementX = movementVector.x;
            movementY = movementVector.y;
        }

    }

    // Destroys the pick up and adds 1 to the counter
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            Destroy(other.gameObject);
            gameManager.UpdateCount(1);
        }

    }

    // Sets the player active status to false and calls game over
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyProjectile"))
        {
            gun.SetActive(false);
            gameObject.SetActive(false);
            gameManager.GameOver();
        }
    }

    // Creates a project from the gun location
    private void spawnProjectile()
    {
        GameObject instFoam = Instantiate(projectile, spawnLocation.transform.position, spawnRotation.transform.rotation);
        Rigidbody instRB = instFoam.GetComponent<Rigidbody>();
        instRB.AddForce(spawnLocation.transform.forward * projectileSpeed * speed);
    }

    // Makes the buttons work for the player
    public void GameStart()
    {
        gameStarted = true;
    }
}
