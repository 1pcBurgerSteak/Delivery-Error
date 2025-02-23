using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class random : MonoBehaviour
{
    public Button[] deliveryButton;
    public string[] names = { "Mia", "Andrew", "Sophia", "Margaret", "Paul", "Amber", "Kanor", "Kajin" };
    public Text[] text;
    public GameObject h;
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        string random = names[UnityEngine.Random.Range(0, names.Length)];
        for (int i = 0; i < text.Length; i++)
        {
            text[i].text = random;
        }

    }
}
