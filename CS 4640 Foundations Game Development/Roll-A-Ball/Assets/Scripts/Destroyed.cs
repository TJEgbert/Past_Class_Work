using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Destroyed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Destroys the object if hits with a playerProjectile
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
