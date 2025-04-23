using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpThroughPlatform : MonoBehaviour
{
    private BoxCollider boxCollider;
    private PlatformCollision topCollision;
    // Start is called before the first frame update
    void Start()
    {
        GameObject childGameObject = gameObject.transform.GetChild(0).gameObject;
        topCollision = childGameObject.GetComponent<PlatformCollision>();
        boxCollider = gameObject.GetComponent<BoxCollider>();

    }

    // Changes the platform so the player well fall through it
    public void SwitchTrigger()
    {
        topCollision.playerFallingThrough = true;
        boxCollider.isTrigger = true;
    }
    // Return the current trigger state of the platform
    public bool IsTriggerState()
    {
        return boxCollider.isTrigger;
    }
}
