using JetBrains.Annotations;
using System.Collections;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class EnemyScript : MonoBehaviour
{
	// give access to the playerchar
	public PlayerScript player;

	// used for checking player on parent
	private bool playerOnParent = false;

	// The health of the enemy
	[SerializeField] float health = 5;
	// The speed of the enemy
	//[SerializeField] float speed = 1;
	// The power of the enemy
	[SerializeField] float power = 1;

	// The game object for health. speed and fireRate increase pickup possible
	[SerializeField] GameObject healthPickup;
	[SerializeField] GameObject speedPickup;
	[SerializeField] GameObject fireRatePickup;

    private AudioSource soundPlayer;
    [SerializeField] AudioClip[] soundEffects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        soundPlayer = gameObject.GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update()
	{
		//if (playerOnParent && player != null)
		//{
			//if (player.transform.position.x > this.transform.position.x)
			//{
			//	Vector2 newPosition = this.transform.position;
			//	newPosition.x += speed / 1000;
			//	this.transform.position = newPosition;
			//}
			//if (player.transform.position.x < this.transform.position.x)
			//{
			//	Vector2 newPosition = this.transform.position;
			//	newPosition.x -= speed / 1000;
			//	this.transform.position = newPosition;
			//}
			//if (player.transform.position.y > this.transform.position.y)
			//{
			//	Vector2 newPosition = this.transform.position;
			//	newPosition.y += speed / 1000;
			//	this.transform.position = newPosition;
			//}
			//if (player.transform.position.y < this.transform.position.y)
			//{
			//	Vector2 newPosition = this.transform.position;
			//	newPosition.y -= speed / 1000;
			//	this.transform.position = newPosition;
			//}
		//}
	}

	public void TakeDamage(float dmg)
	{
		health -= dmg;
        soundPlayer.PlayOneShot(soundEffects[0], 0.7f);
        //Debug.Log(health);
        if (health <= 0)
		{
            // run the drop item script
            //Debug.Log("Pre");
            DropPickupItem();
            //Debug.Log("Post");
            Destroy(gameObject);
			player.PlayEnemyDeathSound();
            Room parentRoom = gameObject.transform.parent.gameObject.GetComponentInParent<Room>();
			GameObject levelGen = GameObject.FindGameObjectWithTag("Level Generator");
			LevelGenerator genScript = levelGen.GetComponent<LevelGenerator>();
			genScript.enemyNum--;
			parentRoom.numberOfEnemies--;
        }
	}

	// update collision between player and parent to see if the player is on the parent matt.
	public void ParentPlayerEnter(bool playerParent)
	{ 
		playerOnParent = playerParent;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerScript playerHit = collision.gameObject.GetComponent<PlayerScript>();

        if (playerHit != null && player.isAlive)
        {
            playerHit.TakeDamage(power);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerScript playerHit = collision.gameObject.GetComponent<PlayerScript>();

        if (playerHit != null)
        {
            playerHit.TakeDamage(power);
        }
    }

	// drop the pickup item based on a random number
	private void DropPickupItem()
	{
		// randomly generate a number between 1 and 10 to determine if the player gets a powerup drop.
		int randomNum = Random.Range(1, 11);
		//Debug.Log("Random Chosen: " + randomNum);
		switch (randomNum) 
		{
			case 1:
				GameObject newDamage = Instantiate(speedPickup, this.transform.position, Quaternion.identity);
				break;
			case 2:
				GameObject newHealth = Instantiate(healthPickup, this.transform.position, Quaternion.identity);
				break;
			case 3:
				GameObject newFireRate = Instantiate(fireRatePickup, this.transform.position, Quaternion.identity);
				break;
			default:
				break;
		}
	}

}
