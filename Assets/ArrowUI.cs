using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ArrowUI : MonoBehaviour
{
    public Transform center;
    void Start()
    {
        
    }


    void Update()
    {
        transform.rotation = center.rotation;
    }
}
