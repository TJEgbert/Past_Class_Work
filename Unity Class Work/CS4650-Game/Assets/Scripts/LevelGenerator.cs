using NavMeshPlus.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{
    // The number of rooms between the exit and start
    [SerializeField] int roomsBetween  = 4;
    // The number of rooms that can contain treasure
    [SerializeField] int numberOfTreasures = 2;
    // The rooms to be used in level generation
    [SerializeField] GameObject[] rooms;
    // Starting location of the likely for a room to contain treasure
    [SerializeField] int treasureSpawnRate = 20;
    // Holds the location of place rooms
    private List<Vector3> usedLocation;
    private SceneHandler sceneHandler;


    GameObject[] surfaces;

    // The number of enemies on the floor
    public int enemyNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //sceneHandler = GameObject.FindGameObjectWithTag("SceneHandler").GetComponent<SceneHandler>();
        usedLocation = new List<Vector3>();
        enemyNum = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Generate();

        surfaces = GameObject.FindGameObjectsWithTag("NavMesh");

        foreach(GameObject surface in surfaces)
        {
            surface.GetComponent<NavMeshSurface>().BuildNavMesh();
        }
    }

    // Update is called once per frame
    void Update()
    {   
    }



    public void Generate()
    {
        GameObject lastConnectedRoom = new GameObject();

        List<GameObject> connectAbleRooms = new List<GameObject>();
        int counter = 0;
        int treasureCount = 0;
        int lastTreasureRoom = 0;
        for (int i = 0; i < rooms.Length; i++)
        {
            GameObject currentObject = rooms[i];
            Room currentRoom = rooms[i].GetComponent<Room>();
            currentRoom.roomIndex = i;
            if (i == 0)
            {
                currentRoom.transform.localPosition = Vector3.zero;
                usedLocation.Add(Vector3.zero);
                currentRoom.start = true;
                connectAbleRooms.Add(rooms[i]);
                lastConnectedRoom = currentObject;
            }
            else
            {
                if (treasureCount < numberOfTreasures)
                {
                    if (i < rooms.Length - 1)
                    {
                        int rand = UnityEngine.Random.Range(0, 101);
                        if(rand <= treasureSpawnRate && i - lastTreasureRoom > 1)
                        {
                            lastTreasureRoom = i;
                            currentRoom.treasure = true;
                            treasureCount++;
                        }
                        treasureSpawnRate += 20;
                    }
                }
                if (counter < roomsBetween)
                {
                    while(!ConnectRooms(lastConnectedRoom, currentObject));
                    connectAbleRooms.Add(currentObject);
                    lastConnectedRoom = currentObject;
                    counter++;
                    if(counter == roomsBetween)
                    {
                        currentObject = rooms[rooms.Length - 1];
                        currentRoom = currentObject.GetComponent<Room>();
                        currentRoom.goal = true;
                        currentRoom.roomIndex = rooms.Length - 1;
                        while(!ConnectRooms(lastConnectedRoom, currentObject));
                        connectAbleRooms.Add(currentObject);
                    }
                }
                else
                {
                    if (i != rooms.Length - 1)
                    {
                        int connectingRoomIndex = UnityEngine.Random.Range(0, connectAbleRooms.Count);
                        while (!ConnectRooms(connectAbleRooms[connectingRoomIndex], currentObject))
                        {
                            connectingRoomIndex = UnityEngine.Random.Range(0, connectAbleRooms.Count);
                        }
                    }
                    connectAbleRooms.Add(currentObject);
                }
            }


        }

        //foreach (GameObject room in rooms)
        //{
        //    Debug.Log(room.GetComponent<Room>().ToString());
        // }
    }

    private bool ConnectRooms(GameObject mainRoomObject, GameObject connectingRoomObject)
    {
        Room mainRoom = mainRoomObject.GetComponent<Room>();
        Room connectingRoom = connectingRoomObject.GetComponent<Room>();
        bool returnBool = false;
        List<string> mainRoomOpenDirections = mainRoom.OpenDirections();
        List<string> connectingRoomDirections = connectingRoom.OpenDirections();
        if (connectingRoomDirections.Count > 0 && mainRoomOpenDirections.Count > 0)
        {
            int directionIndex = UnityEngine.Random.Range(0, mainRoomOpenDirections.Count);
            //Console.Write("the direction idex is: " + directionIndex + "" + "\n");
            string direction = mainRoomOpenDirections[directionIndex];

            if (direction == "forward" && connectingRoomDirections.Contains("backward"))
            {
                Vector3 location = new Vector3(mainRoomObject.transform.position.x, mainRoomObject.transform.position.y + 300);
                if(!usedLocation.Contains(location))
                {
                    returnBool = true;
                    mainRoom.north = connectingRoom.roomIndex;
                    connectingRoom.south = mainRoom.roomIndex;
                    connectingRoomObject.transform.position = location;
                    usedLocation.Add(location);
                }
            }
            else if (direction == "backward" && connectingRoomDirections.Contains("forward"))
            {
                Vector3 location = new Vector3(mainRoomObject.transform.position.x, mainRoomObject.transform.position.y - 300);
                if (!usedLocation.Contains(location))
                {
                    returnBool = true;
                    mainRoom.south = connectingRoom.roomIndex;
                    connectingRoom.north = mainRoom.roomIndex;
                    connectingRoomObject.transform.position = location;
                    usedLocation.Add(location);
                }
            }
            if (direction == "right" && connectingRoomDirections.Contains("left"))
            {
                Vector3 location = new Vector3(mainRoomObject.transform.position.x + 300, mainRoomObject.transform.position.y);
                if(!usedLocation.Contains(location))
                {
                    returnBool = true;
                    mainRoom.east = connectingRoom.roomIndex;
                    connectingRoom.west = mainRoom.roomIndex;
                    connectingRoomObject.transform.position = location;
                    usedLocation.Add(location);
                }
            }
            if (direction == "left" && connectingRoomDirections.Contains("right"))
            {
                Vector3 location = new Vector3(mainRoomObject.transform.position.x - 300, mainRoomObject.transform.position.y);
                if(!usedLocation.Contains(location))
                {
                    returnBool = true;
                    mainRoom.west = connectingRoom.roomIndex;
                    connectingRoom.east = mainRoom.roomIndex;
                    connectingRoomObject.transform.position = location;
                    usedLocation.Add(location);
                }
            }

        }

        return returnBool;
    }
}
