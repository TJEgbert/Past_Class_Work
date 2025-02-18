using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    public bool playerFallingThrough = false;
    private BoxCollider parentCollider;
    // Start is called before the first frame update
    void Start()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        parentCollider = parent.GetComponent<BoxCollider>();
    }
  
    // Allows the player to stand and go specific platforms
    private void OnTriggerEnter(Collider other)
    {
        float y = other.attachedRigidbody.velocity.y;
        // Checks if the player is coming from above the platform 
        if (parentCollider.isTrigger && y < 0 && !playerFallingThrough)
        {
            // Makes the platform solid
            parentCollider.isTrigger = false;
        }
        // Checks if the player is jumping through the platform
        if (!parentCollider.isTrigger && y > 0)
        {
            // Makes the platform not solid
            parentCollider.isTrigger = true;
        }

    }
}
