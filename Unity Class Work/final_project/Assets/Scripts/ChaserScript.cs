using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserScript : MonoBehaviour
{
    [SerializeField] float speed = 5;  // How fast the enemy moves
    [SerializeField] GameObject deathFlames;

    private bool chasePlayer = false;
    private float playerXPosition = 0.0f;
    private Vector3 startPosition;

    private Rigidbody rb;
    private Animator m_Animator;
    private AudioSource audioPlayer;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the starting position of the enemy
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        GameObject[] gameControllerObj = GameObject.FindGameObjectsWithTag("GameController");
        gameController = gameControllerObj[0].GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        // If player is in aggro range and is not dead
        if (chasePlayer && gameController.IsPlayerAlive())
        {
            rb.velocity = new Vector2(MoveDirection() * speed, 0.0f);
        }
        else
        {
            // Teleports back TODO: Fix this so the enemy walks back to
            transform.position = startPosition;
            audioPlayer.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If player is in aggro range
        if (other.tag == "Player")
        {
            m_Animator.SetBool("PlayerInRange", true);
            playerXPosition = other.transform.position.x;
            chasePlayer = true;
            audioPlayer.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Player leaves aggro range
        if (other.tag == "Player")
        {
            m_Animator.SetBool("PlayerInRange", false);
            chasePlayer = false;
            audioPlayer.Stop();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        // If hit with with an players projectile
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            m_Animator.SetTrigger("Death");
            Instantiate(deathFlames, gameObject.transform.position, gameObject.transform.rotation);
            chasePlayer = false;
            Destroy(gameObject, 0.5f);
        }
    }

    // Has the enemy more in the right direction.
    private float MoveDirection()
    {
        float dir = 1.0f;
        if (playerXPosition < startPosition.x)
        {
            dir*= -1;
        }
        return dir;
    }
}
