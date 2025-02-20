using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public Manager manager;
    int coins = 0;
    public int speedLevel = 0;

    public Slider fuelSlider;
    public Slider healthSlider;
    public Slider speedSlider;
    public TextMeshProUGUI speedCost;

    int upgradeCost = 0;
    void Start()
    {
        coins = manager.coins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Repair()
    {
        int cost = 10;
        if(coins >= cost)
        {
            manager.currentDamage += 10;
            healthSlider.value += 10;
            manager.UpdateCoin(cost);
        }
    }

    public void Refuel()
    {
        int cost = 10;
        if (coins >= cost)
        {
            manager.currentFuel += 10;
            fuelSlider.value += 10;
            manager.UpdateCoin(cost);
        }
    }

    public void Upgrade()
    {
        upgradeCost += 10;
        speedCost.text = " " + upgradeCost;
        if (coins >= upgradeCost && speedLevel < 5)
        {
            speedLevel++;
            speedSlider.value = speedLevel;
            manager.currentSpeed += 5;
            manager.UpdateCoin(upgradeCost);
        }
    }
}
