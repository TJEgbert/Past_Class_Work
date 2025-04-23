using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    // Holds the main camera of the scene
    private Camera m_Camera;
    // Holds the parent room script
    private Room parentScript;
    // Offset added to the camera and player
    [SerializeField] float offSet = 300;
    // Will need to add player offset later
    private bool playerEntered = false;

    void Start()
    {
        m_Camera = Camera.main;
        parentScript = gameObject.transform.parent.GameObject().GetComponent<Room>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;

        if (player.tag == "Player" && !playerEntered)
        {
            playerEntered = true;
            // Gets the playscript
            PlayerScript playerScript = player.GetComponent<PlayerScript>();
            string ownTag = gameObject.tag;
            Vector3 cameralocation = Vector3.zero;
            Vector3 playerLocation = Vector3.zero;
            // Creates new vectors based on the direction of the door object tag
            switch (ownTag)
            {
                case "North":
                    playerLocation = new Vector3(m_Camera.transform.position.x, m_Camera.transform.position.y + offSet - 6);
                    cameralocation = new Vector3(m_Camera.transform.position.x, m_Camera.transform.position.y + offSet, m_Camera.transform.position.z);
                    playerScript.currentRoom = parentScript.north;
                    break;
                case "East":
                    playerLocation = new Vector3(m_Camera.transform.position.x + offSet - 17, m_Camera.transform.position.y);
                    cameralocation = new Vector3(m_Camera.transform.position.x + offSet, m_Camera.transform.position.y, m_Camera.transform.position.z);
                    playerScript.currentRoom = parentScript.east;
                    break;
                case "South":
                    playerLocation = new Vector3(m_Camera.transform.position.x, m_Camera.transform.position.y - offSet + 6);
                    cameralocation = new Vector3(m_Camera.transform.position.x, m_Camera.transform.position.y - offSet, m_Camera.transform.position.z);
                    playerScript.currentRoom = parentScript.south;
                    break;
                case "West":
                    playerLocation = new Vector3(m_Camera.transform.position.x - offSet + 17, m_Camera.transform.position.y);
                    cameralocation = new Vector3(m_Camera.transform.position.x - offSet, m_Camera.transform.position.y, m_Camera.transform.position.z);
                    playerScript.currentRoom = parentScript.west;
                    break;
            }
            m_Camera.transform.position = cameralocation;
            player.transform.position = playerLocation;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerEntered = false;
    }

}
