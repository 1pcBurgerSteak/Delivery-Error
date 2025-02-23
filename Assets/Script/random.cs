using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Random : MonoBehaviour
{
    public Button[] deliveryButton;
    public string[] names = { "Mia", "Andrew", "Sophia", "Margaret", "Paul", "Amber", "Kanor", "Kajin" };
    public TMP_Text[] text;
    public GameObject h;

    void Start()
    {
    }

    void Update()
    {
        string random = names[UnityEngine.Random.Range(0, names.Length)];

        for (int i = 0; i < text.Length; i++)
        {
            text[i].text = random;
        }
    }
}
