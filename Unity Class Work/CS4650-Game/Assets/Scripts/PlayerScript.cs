using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    // serialize the object
    [SerializeField] private Rigidbody2D rb;

    // These variables ar to hold the Action reverences
    InputAction moveAction;
    InputAction shootingAction;

    // This is used to limit player damage
    private float playerImmuneTimer = 0;
    private bool playerCanTakeDamage = true;

    // Location for the projectile to spawn
    [SerializeField] GameObject spawnLocation;

    // The game object that being shot
    [SerializeField] GameObject projectile;

    // The speed of the projectile
    [SerializeField] float projectileSpeed = 50.0f;
    private float p_projectileSpeed;

    // The cool down time of the projectile spawn
    [SerializeField] float fireRate = 0.3f;
    private float p_fireRate;

    // Used for speed variability
    [SerializeField] float speed = 1;
    private float p_speed;

    // Used for health variability
    [SerializeField] float health = 5;
    private float p_health;

    // Used to track a projectile has been fired
    private bool fired = false;

    // Tracks the room the player is in
    public int currentRoom = 0;

    private static PlayerScript instance;

    // Gain access to the health script for the player to display player's remaining health
    [SerializeField] private TMPro.TMP_Text healthText;

    private SceneHandler sceneHandler;

    public bool isAlive;

    private AudioSource soundPlayer;
    [SerializeField] AudioClip[] soundEffects;
    [SerializeField] float soundEffectVolume = 1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootingAction = InputSystem.actions.FindAction("Shooting");
        //healthText = GameObject.FindGameObjectWithTag("PlayersHealth").GetComponent<TMPro.TMP_Text>();
        sceneHandler = GameObject.FindGameObjectWithTag("SceneHandler").GetComponent<SceneHandler>();
        soundPlayer = gameObject.GetComponent<AudioSource>();
        p_projectileSpeed = projectileSpeed;
        p_fireRate = fireRate;
        p_speed = speed;
        p_health = health;
        UpdateHealthDisplay();
        isAlive = true;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 shootingVector = shootingAction.ReadValue<Vector2>();

        float x = shootingVector.x;
        float y = shootingVector.y;

        if (x != 0 || y != 0)
        {
            if(!fired)
            {
                FireProjectile(shootingVector);
            }
        }

        // countdown till player can take damage again
        if (!playerCanTakeDamage)
        {
            playerImmuneTimer -= Time.deltaTime;
		}
        if (playerImmuneTimer <= 0)
        {
            playerCanTakeDamage = true;
        }

    }

	// Fixed update runs last for smoothing out
	private void FixedUpdate()
	{
        // Read the Move action value, which is a 2d Vector
        //rb.linearVelocity = moveAction.ReadValue<Vector2>().x = ;
        Vector2 inputVector = moveAction.ReadValue<Vector2>();

        rb.linearVelocity = new Vector2(inputVector.x * speed, inputVector.y * speed);
	}

    public void IncreaseSpeed()
    {
        speed += 1;
    }

    // called whenever a fire rate pick-up is obtained
    public void IncreaseFireRate(float reduction)
    {
        if (fireRate > 0.3)
        {
            fireRate -= reduction;
        }
    }

    private IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireRate);
        fired = false;
    }

    /// <summary>
    /// Creates an instance of projectile and fires it from spawnLocation
    /// </summary>
    /// <param name="vector"></param>
    private void FireProjectile(Vector2 vector)
    {
        soundPlayer.PlayOneShot(soundEffects[0], soundEffectVolume);
        // Move the spawnLocation into place
        spawnLocation.transform.position = new Vector3(vector.x + transform.position.x, vector.y + transform.position.y, 0);
        // Creates projectile and fires it
        GameObject newProjectile = Instantiate(projectile, spawnLocation.transform.position, spawnLocation.transform.rotation);
        Rigidbody2D projectileRB = newProjectile.GetComponent<Rigidbody2D>();
        projectileRB.AddForce(vector * 2 * projectileSpeed * speed);
        fired = true;
        StartCoroutine(FireRate());
    }


    // take damage whenever hit
    public void TakeDamage(float damageNum)
    {
		if (playerCanTakeDamage & isAlive)
        {
            soundPlayer.PlayOneShot(soundEffects[1], soundEffectVolume);
            health -= damageNum;
            playerImmuneTimer = 0.5f;
            playerCanTakeDamage = false;
            if (health <= 0)
            {
                soundPlayer.PlayOneShot(soundEffects[5], soundEffectVolume - 0.3f);
                gameObject.transform.position = new Vector3(0, 0);
                health = 0;
                isAlive = false;
				sceneHandler.PlayerDied();
            }
            UpdateHealthDisplay();
        }
    }


    public void HealPoints(float increaseAmount)
    {
        health += increaseAmount;
        UpdateHealthDisplay();
    }

    public void SpeedPickup(float increaseAmount)
    {
        speed += increaseAmount;
    }

    public void ResetPlayerStats()
    {
        projectileSpeed = p_projectileSpeed;
        fireRate = p_fireRate;
        speed = p_speed;
        health = p_health;
        currentRoom = 0;
        UpdateHealthDisplay();
        isAlive = true;
        fired = false;
    }

    public float GetHealth()
    {
        return health;
    }
    public void UpdateHealthDisplay()
    {
        healthText.text = "Health: " + health.ToString();
    }

    public void PlayHealthPickSound()
    {
        soundPlayer.PlayOneShot(soundEffects[2], soundEffectVolume);
    }

    public void PlayOtherPickSound()
    {
        soundPlayer.PlayOneShot(soundEffects[3], soundEffectVolume);
    }

    public void PlayEnemyDeathSound()
    {
        soundPlayer.PlayOneShot(soundEffects[4], soundEffectVolume);
    }
}
