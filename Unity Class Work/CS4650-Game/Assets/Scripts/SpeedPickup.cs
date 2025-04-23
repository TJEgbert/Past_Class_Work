using UnityEngine;

public class SpeedPickup : MonoBehaviour
{
	// Serialize the amount of health regenerated with this pickup
	[SerializeField] float speedAmnt = 1;

	public void OnTriggerEnter2D(Collider2D collision)
	{
		PlayerScript playerHealthPickup = collision.gameObject.GetComponent<PlayerScript>();

		if (playerHealthPickup != null)
		{
            //Debug.Log("TestingPickup");
            playerHealthPickup.PlayOtherPickSound();
            playerHealthPickup.SpeedPickup(speedAmnt);
			Destroy(gameObject);
		}
	}
}
