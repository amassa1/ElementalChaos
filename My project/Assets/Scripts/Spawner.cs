using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private gameManager gmanager;

    public GameObject[] objectsToSpawn;
    public float spawnSecondsDelay;

    public float spawnLocationBoundX;
    public float spawnLocationBoundZ;



    private void Start()
    {
        gmanager = GameObject.Find("Game Manager").GetComponent<gameManager>();
        InvokeRepeating("Spawn", 1, spawnSecondsDelay);
    }           


    private void Spawn()
    {
        Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], GenerateRandomSpawnPosition(), objectsToSpawn[0].transform.rotation);        
    }

    private Vector3 GenerateRandomSpawnPosition()
    {
        return new Vector3(Random.Range(-spawnLocationBoundX, spawnLocationBoundX), 1, Random.Range(-spawnLocationBoundZ, spawnLocationBoundZ));
    }
}
