using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int hitPoints = 3;
    [SerializeField] int maxHitPoints = 3;
    [SerializeField] float speed = 10.0f;
    [SerializeField] float jump = 10.0f;
    [SerializeField] float projectileSpeed = 30.0f;
    [SerializeField] float jumpDuration = 2.0f;
    [SerializeField] float invisibilityTime = 2.0f;
    [SerializeField] float soundEffectVol = 1.0f;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject spawner;
    [SerializeField] AudioClip[] soundEffects;

    private Vector2 inputVector;
    private float currentY = 0.0f;
    private float wallDirection = 0.0f;
    private float maxJump = 0.0f;
    private float distanceToGround = 0.0f;

    private bool grounded = true;
    private bool jumping = false;
    private bool onWall;
    private bool falling = false;
    private bool invisible = false;
    private bool footStepsPlaying = false;

    private AudioSource soundPlayer;
    private Rigidbody playerRigidbody;
    private PlayerAction playerInputActions;
    private GameController gameController;
    private Animator m_Animator;
    private CapsuleCollider capsuleCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        GameObject[] gameControllerObj = GameObject.FindGameObjectsWithTag("GameController");
        gameController = gameControllerObj[0].GetComponent<GameController>();
        soundPlayer = gameObject.GetComponent<AudioSource>();
        OnStart();
    }

    private void Update()
    {
        if (invisible)
        {
            StartCoroutine(InvisibilityFrames());
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        distanceToGround = capsuleCollider.bounds.extents.y;
        currentY = transform.transform.position.y;
        inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();

        Walking(inputVector.x);
        rotatePlayer(inputVector);
        
        // Handles jumping
        if (grounded)
        {
            // Player is on the ground
            playerRigidbody.velocity = new Vector2(inputVector.x * speed, playerRigidbody.velocity.y);
        } 
        else
        {
            //  Player is jumping until currentY = maxJump distance or the jump button is let go
            if(jumping && currentY <= maxJump && !falling)
            {
              
                playerRigidbody.velocity = new Vector2(inputVector.x * speed, jump);
            }
            else
            {
                // While the player is falling
                falling = true;
                if (onWall && inputVector.x == wallDirection) 
                {
                    // Prevents the player from getting stuck on walls
                    playerRigidbody.velocity = new Vector2(inputVector.x * speed * 0, playerRigidbody.velocity.y);
                }
                else
                {
                    // Normal jumping mechanics
                    playerRigidbody.velocity = new Vector2(inputVector.x * speed, playerRigidbody.velocity.y);
                }
            }
            // Once the player hits the ground
            if (playerRigidbody.velocity.y < 0.01f && playerRigidbody.velocity.y > -0.01f && !onWall)
            {
                grounded = true;
                falling = false;
                soundPlayer.PlayOneShot(soundEffects[1], soundEffectVol);
                soundPlayer.Play();
            }
        }
        // Sets the animation state of the jumping animation
        m_Animator.SetInteger("Jumping", (int)playerRigidbody.velocity.y);
  
    }

    #region Inputs and Controll

    // Handles jumping
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && grounded)
        {
            soundPlayer.Stop();
            grounded = false;
            jumping = true;
            maxJump = currentY += jumpDuration;
            soundPlayer.PlayOneShot(soundEffects[0], soundEffectVol);
            
        }
        if (context.canceled)
        {
            jumping = false;
        }
    }
    // Handles the firing of projectiles for player
    public void Fire(InputAction.CallbackContext context) 
    {
        // Checks if the player can shoot
        if (gameController.canFire())
        {
            m_Animator.SetTrigger("Fire");
            GameObject bullet = Instantiate(projectile, spawner.transform.position, spawner.transform.rotation);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.AddForce(spawner.transform.forward * 10 * projectileSpeed);
            gameController.NumberOfProjectileUpdate(1);
        }
    }

    // Deactivate all platforms see TODO in platforms
    public void PressedDown(InputAction.CallbackContext context)
    {
        gameController.DeactivatePlatform();
    }

    // Rotates the player
    private void rotatePlayer(Vector2 currentInput)
    {
        // Turns the player to the right
        if (currentInput.x > 0 && transform.rotation.y < 0.0f)
        {
            transform.rotation *= Quaternion.Euler(0, 180, 0);
        }
        else if (currentInput.x < 0 && transform.rotation.y >= 0.0f)
        {
            // Turns the player to the left
            transform.rotation *= Quaternion.Euler(0, -180, 0);
        }
    }

    // Checks if the player is dead
    private bool IsDead()
    {
        return hitPoints == 0;
    }

    // Handles walking animation and sound
    private void Walking(float currentDirection)
    {
        if (currentDirection != 0.0f)
        {
            m_Animator.SetBool("IsWalking", true);
            if (!footStepsPlaying)
            {
                soundPlayer.Play();
                footStepsPlaying = true;
            }
        }
        else
        {
            m_Animator.SetBool("IsWalking", false);

            soundPlayer.Stop();
            footStepsPlaying = false;
        }
    }

    // Heals the player back to max TODO: Update to handle different amounts
    public void Heal()
    {
        hitPoints = maxHitPoints;
        gameController.UpdateHitPoints(hitPoints);
    }
    // Takes on hit of damage TODO: Updated to handle different amounts
    private void PlayerTookDamage()
    {
        hitPoints--;
        gameController.UpdateHitPoints(hitPoints);
        soundPlayer.PlayOneShot(soundEffects[2], soundEffectVol);
        if (IsDead())
        {
            OnDeath();
        }
        else
        {
            invisible = true;
        }
    }

    // Sets the player so they can be hurt again. TODO: add knockback
    IEnumerator InvisibilityFrames()
    {
        yield return new WaitForSeconds(invisibilityTime);
        invisible = false;
    }

    #endregion

    #region On Death and Start
    private void OnDeath()
    {
        gameController.PlayerDied();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed -= Jump;
        playerInputActions.Player.Jump.canceled -= Jump;
        playerInputActions.Player.Fire.performed -= Fire;
        playerInputActions.Player.Down.performed -= PressedDown;
        gameController.UpdateUI(true);
        Destroy(gameObject);
    }

    private void OnStart()
    {
        playerInputActions = new PlayerAction();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Player.Jump.canceled += Jump;
        playerInputActions.Player.Fire.performed += Fire;
        playerInputActions.Player.Down.performed += PressedDown;
    }

    #endregion

    #region Collision
    private void OnCollisionEnter(Collision collision)
    {
        // If player is in contact with a wall
        if (collision.gameObject.tag == "Wall")
        {
            
            wallDirection = inputVector.x;
            onWall = true;
        }
        // If player is not invisible
        if (!invisible) 
        {
            // If player is hit with projectile TODO: Handle health in player?
            if (collision.gameObject.tag == "EnemyProjectile")
            {
                PlayerTookDamage();
            }
        }

    }

    // If player and enemies still colliding 
    private void OnCollisionStay(Collision collision)
    {
        if (!invisible) 
        {
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyProjectile")
            {
                PlayerTookDamage();
            }
        }
    }

    // Player is not touching wall
    private void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.tag == "Wall")
        {
            onWall = false;
        }
    }
    #endregion
}
