using UnityEngine;

public class FireRatePickup : MonoBehaviour
{
	// Serialize the amount of fireRate reduced with this pickup
	[SerializeField] float fireReduceAmnt = 0.05f;

	public void OnTriggerEnter2D(Collider2D collision)
	{
		PlayerScript fireRatePickup = collision.gameObject.GetComponent<PlayerScript>();
		if (fireRatePickup != null)
		{
            fireRatePickup.PlayOtherPickSound();
            fireRatePickup.IncreaseFireRate(fireReduceAmnt);
			Destroy(gameObject);
		}
	}
}
