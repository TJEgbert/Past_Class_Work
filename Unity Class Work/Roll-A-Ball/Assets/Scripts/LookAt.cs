using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    // Used to store main camera
    private Camera cam;
    // Used to store the player GameObject
    [SerializeField] GameObject player;

    // Used to get the offset.
    [SerializeField] Vector3 offset = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the mouse position
        var lookAtPos = Input.mousePosition;
        // Gets the player z location calculating 2D y position
        lookAtPos.z = cam.transform.position.y - transform.position.y;
        // Gets the location of the mouse
        lookAtPos = cam.ScreenToWorldPoint(lookAtPos);
        // Turns the gun to point towards the mouse
        transform.forward = lookAtPos - transform.position;
    }

    void LateUpdate()
    {
        // Moves the gun location
        transform.position = player.transform.position + offset;
    }

    // Used to set a firing range for the player
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerProjectile")
        {
            Destroy(other.gameObject);
        }
    }
}
