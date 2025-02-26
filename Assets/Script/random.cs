using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class random : MonoBehaviour
{
    public Button[] deliveryButton;
    public string[] names = { "Mia", "Andrew", "Sophia", "Margaret", "Paul", "Amber", "Kanor", "Kajin" };
    public TextMeshProUGUI[] text;
    public GameObject h;
    public int index = 0;
    void Start()
    {
       
    }

    void Update()
    {
        if (index <= 5)
        {
            // Create a temporary list to store available names without modifying the original array
            List<string> availableNames = new List<string>(names);

            for (int i = 0; i < text.Length; i++)
            {
                if (availableNames.Count == 0)
                    break; // Stop if there are no more unique names left

                int randomIndex = UnityEngine.Random.Range(0, availableNames.Count);
                text[i].text = availableNames[randomIndex];

                // Remove the selected name to prevent duplicates
                availableNames.RemoveAt(randomIndex);
            }

            index++;
        }
    }


}
