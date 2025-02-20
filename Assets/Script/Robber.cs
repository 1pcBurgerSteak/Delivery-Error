using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robber : MonoBehaviour
{
    public Transform target;
    public Transform pos;

    public bool back = false;
    public bool stop = false;


    public float knockbackForce = 5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void FixedUpdate()
    {

      
            transform.position = Vector3.MoveTowards(transform.position, target.position, 3 * Time.deltaTime);
        

          




       


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            stop = true;
            Debug.Log("health - 1");
            //Vector2 knockbackDirection = transform.position - collision.transform.position;
            //rb.AddForce(knockbackDirection.normalized * knockbackForce, ForceMode2D.Impulse);
        }
    }
}
