using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] int totalProjectile = 4;
    [SerializeField] TextMeshProUGUI hitPoints;
    [SerializeField] TextMeshProUGUI youWin;
    [SerializeField] TextMeshProUGUI youLose;
    [SerializeField] Canvas UI;
    [SerializeField] Canvas endGame;
    [SerializeField] float fadeDuration = 1.0f;
   
    private float displayImageDuration = 1.1f;
    private float timer;
    private int numberOfProjectiles = 0;
    private bool fade = false;
    private bool playerAlive = true;

    private GameObject[] platforms;
    private AudioSource audioPlayer;
    private CanvasGroup fader;
    // Start is called before the first frame update
    void Start()
    {
        fader = endGame.GetComponent<CanvasGroup>();
        platforms = GameObject.FindGameObjectsWithTag("Platform");
        audioPlayer = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Handle the fade out at level completion or failure
        if(fade && fader.alpha < displayImageDuration)
        {
            timer += Time.deltaTime;
            fader.alpha = timer / fadeDuration;
        }
    }

    // Updates the UI accordingly if the player won or lost
    public void UpdateUI(bool lost)
    {
        UI.gameObject.SetActive(false);
        endGame.gameObject.SetActive(true);
        fade = true;
        audioPlayer.Stop();
        // Display the correct canvas
        if (lost)
        {
            youLose.gameObject.SetActive(true);
        }
        else
        {
            youWin.gameObject.SetActive(true);
        }
    }

    // Handles the number of projectiles
    public void NumberOfProjectileUpdate(int num)
    {
        numberOfProjectiles += num;
    }

    // Tells if the player can shot again or not
    public bool canFire()
    {
        return numberOfProjectiles != totalProjectile;
    }

    // Deactivates all platforms TODO: Fixit so only one platform is deactivated
    public void DeactivatePlatform()
    {
        foreach (GameObject platform in platforms)
        {
            platform.GetComponent<JumpThroughPlatform>().SwitchTrigger();
        }
    }

    // Updates the UI for the number of hits left for the player
    public void UpdateHitPoints(int hitPoint)
    {
        hitPoints.text = "Hits: " + hitPoint.ToString();
    }

    // Restarts the level
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    // Sets playerAlive to false
    public void PlayerDied()
    {
        playerAlive = false;
    }
    
    // Lets anyone check the current status of the player
    public bool IsPlayerAlive()
    {
        return playerAlive;
    }

    // Closes the game
    public void QuiteGame()
    {
        Application.Quit();
    }
}
