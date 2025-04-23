using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Teleporter2 : MonoBehaviour
{
	private SceneHandler2 sceneHandler;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		sceneHandler = GameObject.FindGameObjectWithTag("SceneHandler").GetComponent<SceneHandler2>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			sceneHandler.ChangeScene(SceneManager.GetActiveScene());
		}
	}
}
