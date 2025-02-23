using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    AudioManager audioManager;
    public float moveSpeed = 5f;
    public float turnSpeed = 100f;
    public float fuel = 100;
    //public static Movement instance;
    public Manager manager;
    public bool chase = false;
    public bool chase2 = false;
    bool isMoving = false;
    float timer = 0f;
    float fuelDecreaseInterval = 1f;

    private Police police;
    private DOG dog;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        police = FindObjectOfType<Police>();
        manager = FindObjectOfType<Manager>();
        dog = FindObjectOfType<DOG>();
    }
    void Update()
    {
        float moveDirection = Input.GetAxis("Vertical");
        float turnDirection = -Input.GetAxis("Horizontal");

        Vector3 move = transform.right * moveDirection * moveSpeed * Time.deltaTime;
        transform.position += move;

        transform.Rotate(Vector3.forward, turnDirection * turnSpeed * Time.deltaTime);

        if (moveDirection != 0 || turnDirection != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            timer += Time.deltaTime;
            if (timer >= fuelDecreaseInterval)
            {
                fuel -= 1;
                timer = 0f;
                manager.UpdateFuel(fuel);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            audioManager.PlaySFX(audioManager.coin);
            manager.UpdateCoin(100);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Delivery"))
        {
            audioManager.PlaySFX(audioManager.coin);
            Deliver deliverScript = collision.GetComponent<Deliver>();
            manager.UpdateDelivery(deliverScript.assignedNum);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Shop"))
        {
            //pedena = true;
            manager.ShowUpgrade();
        }

        if (collision.gameObject.CompareTag("Minimum") && dog.back == false)
        {
            chase = true;
        }
        if (collision.gameObject.CompareTag("Min") && police.back == false)
        {
            chase2 = true;
        }

    }
}
