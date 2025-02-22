using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class SpawnTarget : MonoBehaviour
{
    AudioManager audioManager;

    public GameObject targetPrefab;
    public Button[] customerList;
    public Transform[] spawnLocation;
    public Point point;
    Deliver deliverScript;
    int customerNumber = 0;

    public GameObject phoneHome;
    public GameObject upgradePanel;
    public GameObject arrowUI;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {

    }

    void Update()
    {

    }

    public void CustomerNumber(int customerNumber)
    {
        this.customerNumber = customerNumber;
    }

    public void TargetSpawn()
    {
        audioManager.PlaySFX(audioManager.click);
        GameObject spawnedTarget = Instantiate(targetPrefab, spawnLocation[Random.Range(0, spawnLocation.Length) ].position, Quaternion.identity);
        point.target = spawnedTarget.transform;

        deliverScript = spawnedTarget.GetComponent<Deliver>();
        deliverScript.assignedNum = customerNumber;
    }

}
