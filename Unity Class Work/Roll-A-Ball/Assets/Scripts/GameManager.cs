using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // UI elements to be used
    public TextMeshProUGUI countText;
    public GameObject title;
    public GameObject winTextObject;
    private int count = 0;

    private bool gameStarted = false;
    // Holds the number of collectables 
    [SerializeField] int collectableCount;
    // Holds a reference to the player
    [SerializeField] PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCount(0);
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the game has been started
        if(!gameStarted)
        {
            // starts game if space is pressed
            if(Input.GetKey(KeyCode.Space))
            {
                playerController.GameStart();
                title.SetActive(false);
                gameStarted = true;
            }
        } 
        else
        {
            // Resets game if R is pressed
            if(Input.GetKey(KeyCode.R))
            {
                RestartGame();
            }
        }
    }

    // Updates the counter and if its the last destroys all enemies
    public void UpdateCount(int num)
    {
        count += num;
        countText.text = "Count: " + count.ToString();
        if (count >= collectableCount)
        {
            winTextObject.SetActive(true);
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }
    }
    // Displays game over text
    public void GameOver()
    {
        winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!  Press R to restart";
        winTextObject.SetActive(true);
    }

    // Restarts the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
