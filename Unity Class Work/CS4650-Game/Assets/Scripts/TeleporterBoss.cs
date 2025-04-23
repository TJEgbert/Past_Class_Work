using System.Collections;
using UnityEngine;

public class TeleporterBoss : MonoBehaviour
{
    [SerializeField] GameObject[] teleportLocation;
    private bool canTeleport = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(resetTeleport());
    }

    // Update is called once per frame
    void Update()
    {
        
        if(canTeleport)
        {
            int teleporterIndext = Random.Range(0, teleportLocation.Length);
            canTeleport = false;
            gameObject.transform.position = teleportLocation[teleporterIndext].transform.position;
            StartCoroutine(resetTeleport());
        }
        
    }


    private IEnumerator resetTeleport()
    {
        yield return new WaitForSeconds(5);
        canTeleport = true;
    }
}
