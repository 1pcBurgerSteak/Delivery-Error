using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Police : MonoBehaviour
{
    AudioManager audioManager;
    public Transform target;
    public GameObject maximum;
    public GameObject minimum;

    public Transform pos;
    public bool back = false;
    private Movement movem;
    public Sprite[] sprite;
    public SpriteRenderer sp;

    public Transform checker1;
    public Transform checker2;
    public Transform checker3;
    public Transform checker4;
    public float knockbackForce = 5f;

    private Rigidbody2D rb;
    private Manager manager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movem = FindObjectOfType<Movement>();
        sp = GetComponent<SpriteRenderer>();
        manager = FindObjectOfType<Manager>();
    }
    public void FixedUpdate()
    {
        if(  target.position.x <  checker1.position.x && target.position.y <= checker1.position.y)
        {
            sp.sprite = sprite[0];
        }else if (target.position.x > checker2.position.x && target.position.y <= checker2.position.y)
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
        if (movem.chase2 == true && back == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 4 * Time.deltaTime);
        }



        if (back == true && movem.chase2 == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos.position, 4 * Time.deltaTime);

            if (gameObject.transform.position == pos.transform.position)
            {
                gameObject.transform.position = pos.transform.position;
                back = false;
            }
        }



    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Max"))
        {
            Debug.Log("Duta");
            back = true;
            movem.chase2 = false;

        }


    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            manager.UpdateHealth(5);

            Debug.Log("health - 1");
            //Vector2 knockbackDirection = transform.position - collision.transform.position;
            //rb.AddForce(knockbackDirection.normalized * knockbackForce, ForceMode2D.Impulse);
        }
    }
}
