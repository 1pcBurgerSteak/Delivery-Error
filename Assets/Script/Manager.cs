using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Manager : MonoBehaviour
{
    public GameObject uiCanvas;
    public GameObject winPanel;
    public GameObject losePanel;

    AudioManager audioManager;
    public int delivered = 0;
    public int deliveryNeeded = 0;
    public int counts = 0;
    public int coins = 0;
    public float currentFuel = -20;
    public int currentDamage = 100;
    public float currentSpeed = 5f;
    public int anomalycount = 0;
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
    public Slider healthSlider2;
    public Slider speedSlider;


    public GameObject Dog;
    public GameObject police;
    public GameObject baricade;
    public GameObject robber;
    public GameObject UFO;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        Time.timeScale = 1;
        LoadStats();
        fuelArrowTransform = fuelArrow.GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        arrowUI = GameObject.Find("Arrow");
        spawn(anomalycount);
        UpdateCoin(coins);
        //UpdateFuel(currentFuel);
        //UpdateHealth(currentDamage);

        if (delivered >= 1)
        {
            for (int i = 0; i < deliveryButton.Length; i++)
            {
                deliveryButton[i].interactable = true;
            }
            anomalycount += 1;
            delivered = 0;
        }

        if(deliveryNeeded >= 40)
        {
            Debug.Log("kingina");
            Time.timeScale = 0;
            uiCanvas.SetActive(false);
            winPanel.SetActive(true);
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
        currentFuel = PlayerPrefs.GetFloat("Fuel", -20);
        currentSpeed = PlayerPrefs.GetFloat("Speed", 5f);
        coins = PlayerPrefs.GetInt("Coins", 0);
        currentDamage = PlayerPrefs.GetInt("Damage", 100);
    }

    public void UpdateHealth(int damage)
    {
        currentDamage -= damage;
        if (currentDamage <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("tangina");
            currentDamage = 0;
            uiCanvas.SetActive(false);
            losePanel.SetActive(true);
        }
    }

    public void UpdateCoin(int coins)
    {
        this.coins = coins;
        coinText.text = ": " + coins;
    }

    public void UpdateFuel(float fuel)
    {
        currentFuel = fuel;
        fuelArrowTransform.localRotation = Quaternion.Euler(0, 0, currentFuel);
        if (currentFuel > 100)
        {
            Time.timeScale = 0;
            Debug.Log("hayop");
            currentFuel = 80;
            uiCanvas.SetActive(false);
            losePanel.SetActive(true);
        }
    }

    public void UpdateDelivery(int assignedNum)
    {
        delivered += 1;
        deliveryNeeded += 1;
        deliveryButton[assignedNum].interactable = false;
        arrowUI.SetActive(false);
        phoneContent.SetActive(true);
        if (delivered >= 1)
        {
            Time.timeScale = 1;
            shop.SetActive(true);
            point.target = shop.transform;
            phoneContent.SetActive(false);
            arrowUI.SetActive(true);
            for (int i = 0; i < deliveryButton.Length; i++)
            {
                deliveryButton[i].interactable = true;
            }
        }
    }

    public void ShowUpgrade()
    {
        upgradePanel.SetActive(true);
        UpdateCoin(50);
        fuelSlider.value = currentFuel;
        healthSlider.value = currentDamage;
        if (currentSpeed == 5f)
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
        Time.timeScale = 1;
    }

    public void count()
    {
        counts += 1;
        Debug.Log(counts);
    }

    public void spawn(int val)
    {
        if (val == 1)
        {
            Dog.SetActive(true);
        }
        else if (val == 2)
        {
            police.SetActive(true);
            audioManager.PlaySFX(audioManager.police_car);
        }
        else if (val == 3)
        {
            robber.SetActive(true);
            audioManager.StopSFX();
        }
        else if (val == 4)
        {
            baricade.SetActive(true);
        }
        else if (val == 5)
        {
            UFO.SetActive(true);
        }
    }

    //public void NewGame()
    //{
    //    Time.timeScale = 1;
    //    delivered = 0;
    //    counts = 0;
    //    coins = 0;
    //    currentFuel = 100f;
    //    currentDamage = 100;
    //    currentSpeed = 5f;
    //    anomalycount = 0;

    //    // Update PlayerPrefs to default values
    //    PlayerPrefs.SetFloat("Fuel", 100f);
    //    PlayerPrefs.SetFloat("Speed", 5f);
    //    PlayerPrefs.SetInt("Coins", 0);
    //    PlayerPrefs.SetInt("Damage", 100);
    //    PlayerPrefs.Save();

    //    // Load default stats
    //    LoadStats();

    //    for (int i = 0; i < deliveryButton.Length; i++)
    //    {
    //        deliveryButton[i].interactable = true;
    //    }

    //    arrowUI.SetActive(false);
    //    phoneContent.SetActive(false);
    //    finishedPanel.SetActive(false);
    //    shop.SetActive(false);
    //    upgradePanel.SetActive(false);

    //    // Reset spawn objects
    //    Dog.SetActive(false);
    //    police.SetActive(false);
    //    baricade.SetActive(false);
    //    robber.SetActive(false);
    //    UFO.SetActive(false);

    //    // Update UI elements
    //    UpdateCoin(coins);
    //    UpdateFuel(currentFuel);
    //    UpdateHealth(currentDamage);
    //}
}
