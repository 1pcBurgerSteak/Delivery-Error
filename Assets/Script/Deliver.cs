using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deliver : MonoBehaviour
{
    AudioManager audioManager;

    public static Deliver instance;
    public int assignedNum = 0;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    audioManager.PlaySFX(audioManager.coin);
        //    Destroy(gameObject);
        //}


    }
}
