using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Robber : MonoBehaviour
{
    public Transform target;
    public Transform pos;

    public bool back = false;
    public bool stop = false;


    public float knockbackForce = 5f;

    private Rigidbody2D rb;
    public Sprite[] sprite;
    public SpriteRenderer sp;

    public Transform checker1;
    public Transform checker2;
    public Transform checker3;
    public Transform checker4;

    private Manager manager;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        manager = FindObjectOfType<Manager>();
    }
    public void FixedUpdate()
    {
        if (target.position.x < checker1.position.x && target.position.y <= checker1.position.y)
        {
            sp.sprite = sprite[0];
        }
        else if (target.position.x > checker2.position.x && target.position.y <= checker2.position.y)
        {
            sp.sprite = sprite[1];
        }
        else if (target.position.y < checker4.position.y && target.position.x > checker4.position.x)
        {
            sp.sprite = sprite[2];
        }
        else if (target.position.y > checker3.position.y && target.position.x > checker3.position.x)
        {
            sp.sprite = sprite[3];
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, 3 * Time.deltaTime);
        

          




       


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            stop = true;
            manager.UpdateHealth(5);

            Debug.Log("health - 1");
            //Vector2 knockbackDirection = transform.position - collision.transform.position;
            //rb.AddForce(knockbackDirection.normalized * knockbackForce, ForceMode2D.Impulse);
        }
    }
}
