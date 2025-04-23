using System.Collections.Generic;
using UnityEngine;

public class TileInteraction : MonoBehaviour
{
	private List<Transform> children = new List<Transform>();

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		// Populate the children list with child transforms
		foreach (Transform child in transform)
		{
			children.Add(child);
		}

		//Debug.Log("Child Objects " + transform.childCount);
	}

	// Update is called once per frame
	void Update()
	{

	}

	//check if the player character is on top of the tile
	public void OnTriggerEnter2D(Collider2D collision)
	{
		PlayerScript playerOnTile = collision.gameObject.GetComponent<PlayerScript>();
		if (playerOnTile != null)
		{
            foreach (var child in children)
			{
				if(child != null)
				{
                    // Access the ParentPlayerEnter method for each child
                    EnemyScript parentInteraction = child.GetComponent<EnemyScript>();
                    if (parentInteraction != null)
                    {
                        parentInteraction.ParentPlayerEnter(true);
                    }
                    else
                    {
                        Debug.LogWarning("Child does not have an EnemyScript component.");
                    }
                }
			}
		}
	}

	//check if the player character leaves the tile
	public void OnTriggerExit2D(Collider2D collision)
	{
		PlayerScript playerOnTile = collision.gameObject.GetComponent<PlayerScript>();

		if (playerOnTile != null)
		{
			foreach (var child in children)
			{
				if (child != null)
				{
                    // Access the ParentPlayerEnter method for each child
                    EnemyScript parentInteraction = child.GetComponent<EnemyScript>();
                    if (parentInteraction != null)
                    {
                        parentInteraction.ParentPlayerEnter(false);
                    }
                    else
                    {
                        Debug.LogWarning("Child does not have an EnemyScript component.");
                    }
                }
			}
		}
	}
}
