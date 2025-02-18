using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] float fadeTimer = 1.0f;
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] gameControllerObj = GameObject.FindGameObjectsWithTag("GameController");
        gameController = gameControllerObj[0].GetComponent<GameController>();
        // Updates the global projectile count
        if(gameObject.tag == "PlayerProjectile")
        {
            gameController.NumberOfProjectileUpdate(-1);
        }
        Destroy(gameObject, fadeTimer);
    }

}
