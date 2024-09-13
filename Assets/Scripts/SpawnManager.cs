using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyBallPrefabs;

    private float spawnRangeX = 16;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ABSTRACTION
    // Method to spawn enemy
    void SpawnRandomBall()
    {
        int index = Random.Range(0, enemyBallPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(enemyBallPrefabs[index], spawnPos, enemyBallPrefabs[index].transform.rotation);
    }

    // ABSTRACTION
    // Method to stop repeating spawning
    public void StopRepeating()
    {
        CancelInvoke("SpawnRandomBall");
    }
}
