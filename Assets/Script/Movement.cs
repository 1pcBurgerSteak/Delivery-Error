using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 100f;
    public float fuel = 100;

    public Manager manager;
    public bool chase = false;
    public bool chase2 = false;
    bool isMoving = false;
    float timer = 0f;
    float fuelDecreaseInterval = 1f;

    private DOG dog;
    private void Start()
    {
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
            manager.UpdateCoin(100);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Delivery"))
        {
            Deliver deliverScript = collision.GetComponent<Deliver>();
            manager.UpdateDelivery(deliverScript.assignedNum);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Shop"))
        {
            manager.ShowUpgrade();
        }

        if (collision.gameObject.CompareTag("Minimum") && dog.back == false)
        {
            chase = true;
        }
        if (collision.gameObject.CompareTag("Min") && dog.back == false)
        {
            chase2 = true;
        }

    }
}
