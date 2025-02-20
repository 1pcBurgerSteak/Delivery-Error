using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    public int delivered = 0;

    public int coins = 0;
    public float currentFuel = 100;
    public int currentDamage = 100;
    public float currentSpeed = 5f;

    public Point point;
    public GameObject finishedPanel;
    public GameObject phoneContent;
    public GameObject arrowUI;
    public Button[] deliveryButton;
    
    public TextMeshProUGUI coinText;
    public GameObject fuelArrow;
    RectTransform fuelArrowTransform;

    public GameObject shop;
    public GameObject upgradePanel;
    public Slider fuelSlider;
    public Slider healthSlider;
    public Slider speedSlider;

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

    public void UpdateCoin(int coins)
    {
        this.coins = coins;
        coinText.text = ": " + coins;
    }

    public void UpdateFuel(float fuel)
    {
        currentFuel = fuel;
        //float newRotation = fuel;
        fuelArrowTransform.localRotation = Quaternion.Euler(0, 0, currentFuel);
    }

    public void UpdateDelivery(int assignedNum)
    {
        delivered += 1;
        deliveryButton[assignedNum].interactable = false;
        phoneContent.SetActive(true);
        arrowUI.SetActive(false);
        if (delivered >= 1)
        {
            shop.SetActive(true);
            point.target = shop.transform;
            phoneContent.SetActive (false);
            arrowUI.SetActive(true);
            finishedPanel.SetActive(true);
        }
    }

    public void ShowUpgrade()
    {
        upgradePanel.SetActive(true);
        fuelSlider.value = currentFuel;
        healthSlider.value = currentDamage;
        if(currentSpeed == 5f)
        {
            speedSlider.value = 0;
        }
        else
        {
            speedSlider.value = currentSpeed / 5;
        }
    }

    public void Continue()
    {
        SaveStats();
    }
}
