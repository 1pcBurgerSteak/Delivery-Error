using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class SpawnTarget : MonoBehaviour
{
    public GameObject targetPrefab;
    public Button[] customerList;
    public Transform[] spawnLocation;
    public Point point;
    Deliver deliverScript;
    int customerNumber = 0;

    public GameObject phoneHome;
    public GameObject arrowUI;
    void Start()
    {

    }

    void Update()
    {
        if (deliverScript.arrived == true)
        {
            customerList[customerNumber].interactable = false;
            phoneHome.SetActive(true);
            arrowUI.SetActive(false);
            customerNumber = 0;
        }
    }

    public void CustomerNumber(int customerNumber)
    {
        this.customerNumber = customerNumber;
    }

    public void TargetSpawn()
    {
        GameObject spawnedTarget = Instantiate(targetPrefab, spawnLocation[0].position, Quaternion.identity);
        point.target = spawnedTarget.transform;

        deliverScript = spawnedTarget.GetComponent<Deliver>();
    }

}
