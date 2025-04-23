using UnityEngine;

public class HealthPickup : MonoBehaviour
{
	// Serialize the amount of health regenerated with this pickup
	[SerializeField] float healthAmnt = 1;


    public void OnTriggerEnter2D(Collider2D collision)
	{	
		PlayerScript playerHealthPickup = collision.gameObject.GetComponent<PlayerScript>();
		if (playerHealthPickup != null)
		{
			//Debug.Log("TestingPickup");
			playerHealthPickup.PlayHealthPickSound();
            playerHealthPickup.HealPoints(healthAmnt);
			Destroy(gameObject);
		}
	}
}
