using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    public int coins = 0;
    public int currentFuel = 100;
    public int currentDamage = 100;
    public float currentSpeed = 5f;

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
        float newRotation = fuel;
        fuelArrowTransform.localRotation = Quaternion.Euler(0, 0, newRotation);
    }
}
