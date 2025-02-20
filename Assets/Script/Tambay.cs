using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tambay : MonoBehaviour
{
    public Transform target;
    public GameObject maximum;
    public GameObject minimum;

    public Transform pos;
    public bool back = false;
    private Movement movem;


    public float knockbackForce = 5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movem = FindObjectOfType<Movement>();
    }
    public void FixedUpdate()
    {

        if (!back)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 4 * Time.deltaTime);
        }
            
        



        if (back == true )
        {
            transform.position = Vector3.MoveTowards(transform.position, pos.position, 4 * Time.deltaTime);

            if (gameObject.transform.position == pos.transform.position)
            {
                gameObject.transform.position = pos.transform.position;
                back = false;
            }
        }



    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Police"))
        {
            Debug.Log("Duta");
            back = true;
           

        }


    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("health - 1");
            //Vector2 knockbackDirection = transform.position - collision.transform.position;
            //rb.AddForce(knockbackDirection.normalized * knockbackForce, ForceMode2D.Impulse);
        }
    }
}
