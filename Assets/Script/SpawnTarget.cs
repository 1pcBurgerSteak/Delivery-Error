using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    public GameObject targetPrefab;
    public Transform[] spawnLocation;
    public Point point;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TargetSpawn()
    {
        GameObject spawnedTarget = Instantiate(targetPrefab, spawnLocation[0].position, Quaternion.identity);
        point.target = spawnedTarget.transform;
    }
}
