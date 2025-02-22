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
    AudioManager audioManager;
    //public static Manager Instance;
    public int delivered = 0;
    public int counts = 0;
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
    public Slider healthSlider2;
    public Slider speedSlider;


    public GameObject Dog;
    public GameObject police;
    //public GameObject[] baricade;
    public GameObject robber;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    //public static Manager Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            GameObject obj = new GameObject("Manager");
    //            instance = obj.AddComponent<Manager>();
    //            DontDestroyOnLoad(obj);
    //        }
    //        return instance;
    //    }
    //}

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

    void Start()
    {
        LoadStats();
        //if (coinText == null)
        //    coinText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();

        //if (fuelSlider == null)
        //    fuelSlider = GameObject.Find("FuelSlider").GetComponent<Slider>();

        //if (healthSlider == null)
        //    healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();

        //if (speedSlider == null)
        //    speedSlider = GameObject.Find("SpeedSlider").GetComponent<Slider>();

        //if (fuelArrow == null)
        //    fuelArrow = GameObject.Find("Fuel Arrow");

        //if (shop == null)
        //    shop = GameObject.Find("Shop Location");

        //if (upgradePanel == null)
        //    upgradePanel = GameObject.Find("Shop UI");

        //if (finishedPanel == null)
        //    finishedPanel = GameObject.Find("Finish Delivery");

        //if (fuelArrow != null && fuelArrowTransform == null)
        //    fuelArrowTransform = fuelArrow.GetComponent<RectTransform>();

        //fuelArrow = GameObject.Find("Fuel Arrow");
        //phoneContent = GameObject.Find("Phone Content");
        //point = FindObjectOfType<Point>();
        //arrowUI = GameObject.Find("Arrow");
        //coinText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
        //fuelSlider = GameObject.Find("FuelSlider").GetComponent<Slider>();
        //healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        //speedSlider = GameObject.Find("SpeedSlider").GetComponent<Slider>();
        //fuelArrowTransform = GameObject.Find("fuelArrowTransform").GetComponent<RectTransform>();
        //shop = GameObject.Find("Shop Location");
        //upgradePanel = GameObject.Find("Shop UI");
        //finishedPanel = GameObject.Find("Finish Delivery");
        fuelArrowTransform = fuelArrow.GetComponent<RectTransform>();


    }
    //void OnEnable()
    //{
    //    SceneManager.sceneLoaded += OnSceneLoaded;
    //}

    //void OnDisable()
    //{
    //    SceneManager.sceneLoaded -= OnSceneLoaded;
    //}

    //void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
       
    //    if (coinText == null)
    //        coinText = GameObject.Find("CoinText")?.GetComponent<TextMeshProUGUI>();

    //    if (fuelSlider == null)
    //        fuelSlider = GameObject.Find("FuelSlider")?.GetComponent<Slider>();

    //    if (healthSlider == null)
    //        healthSlider = GameObject.Find("HealthSlider")?.GetComponent<Slider>();

    //    if (speedSlider == null)
    //        speedSlider = GameObject.Find("SpeedSlider")?.GetComponent<Slider>();

    //    if (fuelArrow == null)
    //        fuelArrow = GameObject.Find("Fuel Arrow");

    //    if (shop == null)
    //        shop = GameObject.Find("Shop Location");

    //    if (upgradePanel == null)
    //        upgradePanel = GameObject.Find("Shop UI");

    //    if (finishedPanel == null)
    //        finishedPanel = GameObject.Find("Finish Delivery");

    //    if (fuelArrow != null && fuelArrowTransform == null)
    //        fuelArrowTransform = fuelArrow.GetComponent<RectTransform>();
    //}
    void LateUpdate()
    {
    arrowUI = GameObject.Find("Arrow");
        spawn(counts);
        UpdateCoin(coins);
        UpdateFuel(currentFuel);
        UpdateHealth(currentDamage);
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

    public void UpdateHealth(int damage)
    {
        currentDamage -= damage;
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
        arrowUI.SetActive(false);
        phoneContent.SetActive(true);
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
   public void count()
    {
        counts = counts + 1;
        Debug.Log(counts);
    }

    public void spawn(int val)
    {
        
           if (val == 1)
        {
            Dog.SetActive(true);
         
        } else if (val == 2) {

            police.SetActive(true);
            Dog.SetActive(false);
            audioManager.PlaySFX(audioManager.police_car);
        }
        else if (val == 3)
        {

            robber.SetActive(true);
            police.SetActive(false);
            audioManager.StopSFX();
        }
    }
}
