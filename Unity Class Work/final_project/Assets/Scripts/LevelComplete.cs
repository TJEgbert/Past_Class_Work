using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        GameObject[] gameControllerObj = GameObject.FindGameObjectsWithTag("GameController");
        gameController = gameControllerObj[0].GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Calls gameController to handle the level complete
            gameController.UpdateUI(false);
        }
    }
}
