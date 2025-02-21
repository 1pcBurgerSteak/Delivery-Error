using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ArrowUI : MonoBehaviour
{
    public Transform center;
    public static ArrowUI instance;

    //void Awake()
    //{

    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }


    //}
    void Start()
    {
        
    }


    void Update()
    {
        transform.rotation = center.rotation;
    }
}
