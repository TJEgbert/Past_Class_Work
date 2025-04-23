using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Holds the object the camera will follow
    public GameObject player;
    
    // The distance between the camera and the player
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the initial offset between the camera and the player
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame after all other Update functions
    void LateUpdate()
    {
        // Maintains the distance between the player and camera
        transform.position = player.transform.position + offset;
    }
}
