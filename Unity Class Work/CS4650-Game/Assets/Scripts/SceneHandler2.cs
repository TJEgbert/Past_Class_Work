using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneHandler2 : MonoBehaviour
{
	// Holds the player
	private GameObject player;
	// Used to track user input
	InputAction restAction;
	InputAction quitAction;
	// Holds the camera
	private Camera mainCamera;
	// Holds the only copy SceneHandler2 in game
	private static SceneHandler2 instance;

	// Holds the starting location of the camrea and player for each flor
	[SerializeField] Vector3 playerStartingLocation = new Vector3(-1, -4);
	[SerializeField] Vector3 cameraStartingLocation = new Vector3(-1, -4.5f, -10);

	// Stores display game objects
	[SerializeField] GameObject winScreen;
	[SerializeField] GameObject loseScreen;
	[SerializeField] GameObject loadScreen;
	[SerializeField] GameObject playersHealth;
	GameObject confirmPanel; // Not serialized as it isn't needed to be edited.  Is built in each floor in boss room.

	// used for the buttons to be reloaded.
	private string nextScene;
	private int floorNum = 1;
	private Button yesButton;
	private Button noButton;
	private bool finalFloor = false;
	private bool displayConfirmPanel = true;

	[SerializeField] float loadTime = 0.7f;

    private AudioSource soundPlayer;
    [SerializeField] AudioClip winJingle;

	// Makes sure this is the only SceneHandler in the game
	private void Awake()
	{
		if (instance != null && instance != this)
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
        soundPlayer = gameObject.GetComponent<AudioSource>();

        BuildNextFloorButtons(); // Initial setup
		SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to scene load event
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (!finalFloor) // only run when it's not the final floor.
			BuildNextFloorButtons(); // Reassign buttons when the new scene is loaded
	}

	void OnDestroy()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded; // Clean up subscription on destroy.
	}

	private void BuildNextFloorButtons()
	{
		// Destroy the old confirmPanel, so that it doesn't get in the way
		if (confirmPanel != null)
		{
			Destroy(confirmPanel);
			Debug.Log("Old ConfirmPanel Destroyed");
		}

		// Find the Boss Room for the floor
		GameObject bossRoom = GameObject.Find("Floor " + floorNum + " Boss");
		if (bossRoom != null)
		{
			// Now find the confirm panel inside Boss Room, so that we can find the buttons inside of it
			confirmPanel = bossRoom.transform.Find("ConfirmPanel")?.gameObject;
		}
		else
		{
			Debug.LogError("Unable to find Boss Room");
		}
		// Verify Confirm Panel Found.
		if (confirmPanel == null)
		{
			Debug.LogError("ConfirmPanel not found in Boss Room");
			return;
		}

		// Find the buttons inside the ConfirmPanel
		yesButton = confirmPanel.transform.Find("Canvas/YesButton")?.GetComponent<Button>();
		noButton = confirmPanel.transform.Find("Canvas/NoButton")?.GetComponent<Button>();

		if (yesButton != null)
		{
			yesButton.onClick.RemoveAllListeners();
			yesButton.onClick.AddListener(ConfirmChangeScene);
			//Debug.Log("Yes Button " + GetHierarchyPath(yesButton.gameObject));
		}
		else
			Debug.LogError("No yesButton Found inside of ConfirmPanel");

		if (noButton != null)
		{
			noButton.onClick.RemoveAllListeners();
			noButton.onClick.AddListener(CancelChangeScene);
			//Debug.Log("No Button " + GetHierarchyPath(noButton.gameObject));
		}
		else
			Debug.LogError("No noButton Found inside of ConfirmPanel");

		// Debug.Log("Boss: " + bossRoom.name); Used to verify the correct boss room found on loaded floor for buttons.
	}

	void Update()
	{
		// If player hits the reset button
		if (restAction.triggered)
		{
			loseScreen.SetActive(false);
			winScreen.SetActive(false);
			SceneManager.LoadScene("Floor1Build");
			player.GetComponent<PlayerScript>().ResetPlayerStats();
			floorNum = 1;
			finalFloor = false;
			displayConfirmPanel = true;
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
		switch (currentScene.name)
		{
			case "Floor1Build":
				nextScene = "Floor2Build";
				floorNum = 2; // Sets the builder up to find the boss room on the next floor so it can find the next floor buttons.
				break;
			case "Floor2Build":
				nextScene = "Floor3Build";
				floorNum = 3;
				break;
			case "Floor3Build":
				nextScene = "Floor4Build";
				finalFloor = true; // This sets the next floor to be the final one.
				break;
			case "Floor4Build":
				soundPlayer.PlayOneShot(winJingle);
				winScreen.SetActive(true);
				break;
		}

		// Show confirmation panel if not the final floor.
		if (displayConfirmPanel)
			confirmPanel.SetActive(true);
	}

	// Displays the loading screen
	private IEnumerator LoadTimer()
	{
		yield return new WaitForSeconds(loadTime);
		loadScreen.SetActive(false);
		playersHealth.SetActive(true);
	}

	// Sets up the next floor that was loaded
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

	// Sets the next floor
	public void ConfirmChangeScene()
	{
		// change so that the confirm panel doesn't try to load when it's the final floor
		if (finalFloor)
			displayConfirmPanel = false;

		Debug.Log("Scene Change " + nextScene);
		GameLoading();
		if (confirmPanel != null)
			confirmPanel.SetActive(false);
		SceneManager.LoadScene(nextScene);
	}

	// Cancels and continues the current floor
	public void CancelChangeScene()
	{
		if (confirmPanel != null)
			confirmPanel.SetActive(false);
	}
}