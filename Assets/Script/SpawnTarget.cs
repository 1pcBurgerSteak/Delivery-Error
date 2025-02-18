using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class SpawnTarget : MonoBehaviour
{
    public GameObject targetPrefab;
    public Transform[] spawnLocation;
    public Point point;
    public GameObject phone;
    public List<Button> buttons = new List<Button>();
    public Button[] buttonArray;
    public bool delivered;
    Target target;
    ArrowUI arrow;

    public static SpawnTarget instance;

    public int i = 0;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        delivered = false;
        arrow = GetComponent<ArrowUI>();

        
        foreach (Button btn in buttonArray)
        {
            btn.onClick.AddListener(() => buttons.Add(btn));
        }
    }

    void Update()
    {
      

        if (delivered)
        {
            
            checker();
        }
    }

    public void TargetSpawn()
    {
        GameObject spawnedTarget = Instantiate(targetPrefab, spawnLocation[i].position, Quaternion.identity);
        point.target = spawnedTarget.transform;
    }

    //public void Comparison()
    //{
        
    //    if (target.canbe == true)
    //    {
    //        delivered = true;
    //    }
    //    else
    //    {
    //        Debug.Log("No similarities");
    //    }
    //}

    public void checker()
    {
        for (int j = 0; j < buttons.Count; j++)
        {
            Button btnInArray = buttons[j];

            
            btnInArray.interactable = false;
            btnInArray.image.color = Color.green;
            Debug.Log(btnInArray.name);
            phone.SetActive(true);
            delivered = false;
        
           
        }
    }
}
