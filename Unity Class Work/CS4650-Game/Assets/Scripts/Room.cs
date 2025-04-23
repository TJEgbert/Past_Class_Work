using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour
{

    [SerializeField] public int north = -1;
    [SerializeField] public int south= -1;
    [SerializeField] public int west = -1;
    [SerializeField] public int east = -1;
    public int numberOfEnemies = 0;
    public int roomIndex { get; set; } = -1;
    public bool treasure { get; set; } = false;
    public bool start { get; set; } = false;
    public bool goal { get; set; } = false;
    [SerializeField] GameObject[]  doors;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Transform enemyContainer = transform.Find("Enemies");
        numberOfEnemies = enemyContainer.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfEnemies <= 0)
        {
            ActivateDoors();
            if(goal)
            {
                GameObject teleporter = transform.Find("NextFloor").gameObject;
                if(teleporter != null)
                {
                    teleporter.SetActive(true);
                }
            }
        }
    }

    public List<int> ConnectedRooms()
    {
        List<int> rooms = new List<int>();

        if (north > 0)
        {
            rooms.Add(north);
        }
        if (south > 0)
        {
            rooms.Add(south);
        }
        if (west > 0)
        {
            rooms.Add(west);
        }
        if (east > 0)
        {
            rooms.Add(east);
        }
        return rooms;
    }

    public List<string> OpenDirections()
    {
        List<string> returnList = new List<string>();
        if (north < 0)
        {
            returnList.Add("forward");
        }
        if (south < 0)
        {
            returnList.Add("backward");
        }
        if (west < 0)
        {
            returnList.Add("left");
        }
        if (east < 0)
        {
            returnList.Add("right");
        }
        return returnList;
    }

    public void clearRooms()
    {
        north = -1;
        south = -1;
        west = -1;
        east = -1;
    }


    public bool IsFull()
    {
        bool full = false;
        if (ConnectedRooms().Count == 0)
        {
            full = true;
        }

        return full;
    }

    public override string ToString()
    {
        string returnString = string.Empty;
        returnString += "Room number is " + roomIndex + " Name: " + this.name +"\n";

        if (start)
        {
            returnString += "This is the starting point\n";
        }
        if (goal)
        {
            returnString += "This is the end point\n";
        }
        if (treasure)
        {
            returnString += "This is a treasure room\n";
        }

        returnString += "The rooms attached to this room are \n";
        if (north >= 0) { returnString += "Forward Room number: " + north + "\n"; }
        if (south >= 0) { returnString += "Backward Room number: " + south + "\n"; }
        if (west >= 0) { returnString += "Left Room number: " + west + "\n"; }
        if (east >= 0) { returnString += "Right Room number: " + east + "\n"; }
        returnString += "Its position is: " + this.transform.localPosition + "\n";
        returnString += "\n";

        return returnString;
    }

    public void UpdateLocation(Vector3 newLocation)
    {
        transform.localPosition = newLocation;
    }

    public void ActivateDoors()
    {
        foreach (GameObject obj in doors)
        {
            switch (obj.tag)
            {
                case "North":
                    if(north >= 0)
                    {
                        obj.SetActive(true);
                    }
                    break;
                case "South":
                    if (south >= 0)
                    {
                        obj.SetActive(true);
                    }
                    break;
                case "East":
                    if (east >= 0)
                    {
                        obj.SetActive(true);
                    }
                    break;
                case "West":
                    if (west >= 0)
                    {
                        obj.SetActive(true);
                    }
                    break;
            }
        }
    }

}
