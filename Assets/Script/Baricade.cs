using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baricade : MonoBehaviour
{
    public Transform[] spawn;
    public GameObject Bar;
    public float timer = 0f;
    public float timer1 = 0f;

    private List<GameObject> spawnedBlocks = new List<GameObject>(); // Store multiple barricades

    void Start()
    {
        //spawner();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 6)
        {
            spawner();
            timer = 0;
        }

        timer1 += Time.deltaTime;

        if (timer1 >= 12 && spawnedBlocks.Count > 0)
        {
            Destroy(spawnedBlocks[0]);
            spawnedBlocks.RemoveAt(0); 
            timer1 = 0;
        }
    }

    public void spawner()
    {
        GameObject newBlock = Instantiate(Bar, spawn[Random.Range(0, spawn.Length)].position, Quaternion.identity);
        spawnedBlocks.Add(newBlock);
    }
}
