using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    // Holds the player
    private GameObject player;
    // Used to track user input
    InputAction restAction;
    InputAction quitAction;
    // Holds the camera
    private Camera mainCamera;
    // Holds the only copy SceneHandler in game
    private static SceneHandler instance;

    // Holds the starting location of the camrea and player for each flor
    [SerializeField] Vector3 playerStartingLocation = new Vector3(-1, -4);
    [SerializeField] Vector3 cameraStartingLocation = new Vector3(-1, -4.5f, -10);

    // Stores display game objects
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject loadScreen;
    [SerializeField] GameObject playersHealth;

    [SerializeField] float loadTime = 0.7f;

    // Makes sure this is the only SceneHandler in the game
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = Camera.main;
        restAction = InputSystem.actions.FindAction("Reset");
        quitAction = InputSystem.actions.FindAction("Quit");
    }

    // Update is called once per frame
    void Update()
    {
        // If player hits the reset button
        if (restAction.triggered)
        {
            loseScreen.SetActive(false);
            winScreen.SetActive(false);
            SceneManager.LoadScene("Floor1");
            player.GetComponent<PlayerScript>().ResetPlayerStats();
            GameLoading();
        }

        // If the player hits the quit button
        if (quitAction.triggered)
        {
            Application.Quit();
        }

    }

    // Handles scene changes for the game
    public void ChangeScene(Scene currentScene)
    {
        switch(currentScene.name)
        {
            case "Floor1":
                GameLoading();
                SceneManager.LoadScene("Floor2");
                break;
            case "Floor2":
                winScreen.SetActive(true);
                break;
        }
    }

    // Displays the loading screen
    private IEnumerator LoadTimer()
    {
        yield return new WaitForSeconds(loadTime);
        loadScreen.SetActive(false);
        playersHealth.SetActive(true);
    }

    // Sets up the next floor the was loaded
    private void GameLoading()
    {
        loadScreen.SetActive(true);
        playersHealth.SetActive(false);
        StartCoroutine(LoadTimer());
        player.transform.position = playerStartingLocation;
        mainCamera.transform.position = cameraStartingLocation;

    }

    // Displays the game over screen
    public void PlayerDied()
    {
        loseScreen.SetActive(true);
    }

    
}
