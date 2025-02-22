using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    public static CameraMove instance;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

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
    public void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y,-10);
    }
}
