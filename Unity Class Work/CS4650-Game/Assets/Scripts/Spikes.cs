using System;
using UnityEngine;

public class Spikes : MonoBehaviour
{
	// The power of the spikes
	[SerializeField] float power = 1;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		PlayerScript playerHit = collision.gameObject.GetComponent<PlayerScript>();

		if (playerHit != null)
		{
			playerHit.TakeDamage(power);
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		PlayerScript playerHit = collision.gameObject.GetComponent<PlayerScript>();

		if (playerHit != null)
		{
			playerHit.TakeDamage(power);
		}
	}
}
