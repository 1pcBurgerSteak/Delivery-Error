using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform[] spawnPoints;
    private float spawnTime;
    private float timeSinceLastSpawn;

    void Start()
    {
        SetRandomSpawnTime();
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnTime)
        {
            SpawnCoin();
            SetRandomSpawnTime(); 
            timeSinceLastSpawn = 0f;
        }
    }

    void SetRandomSpawnTime()
    {
        spawnTime = UnityEngine.Random.Range(2f, 10f);
    }

    void SpawnCoin()
    {
        Transform spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
        Instantiate(coinPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

