using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    private int delivered = 0;

    public int coins = 0;
    public float currentFuel = 100;
    public int currentDamage = 100;
    public float currentSpeed = 5f;

    public GameObject upgradePanel;

    public TextMeshProUGUI coinText;
    public GameObject fuelArrow;
    RectTransform fuelArrowTransform;

    void Start()
    {
        LoadStats();
        fuelArrowTransform = fuelArrow.GetComponent<RectTransform>();
    }

    void Update()
    {
        if(delivered >= 5)
        {

        }
    }

    public void SaveStats()
    {
        PlayerPrefs.SetFloat("Fuel", currentFuel);
        PlayerPrefs.SetFloat("Speed", currentSpeed);
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("Damage", currentDamage);
        PlayerPrefs.Save();
    }

    public void LoadStats()
    {
        currentFuel = PlayerPrefs.GetInt("Fuel", 100);
        currentSpeed = PlayerPrefs.GetFloat("Speed", 5f);
        coins = PlayerPrefs.GetInt("Coins", 0);
        currentDamage = PlayerPrefs.GetInt("Damage", 100);
    }

    public void UpdateCoin()
    {
        coins += 1;
        coinText.text = ": " + coins;
    }

    public void UpdateFuel(float fuel)
    {
        currentFuel = fuel;
        float newRotation = fuel;
        fuelArrowTransform.localRotation = Quaternion.Euler(0, 0, newRotation);
    }

    public void UpdateDelivery()
    {
        delivered += 1;
    }

    public void ShowUpgrade()
    {

    }
}
