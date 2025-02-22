using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOG : MonoBehaviour
{
    public Transform target;
    public GameObject maximum;
    public GameObject minimum;
    //public GameObject dright;
    //public GameObject dleft;
    //public GameObject dup;
    //public GameObject ddown;
    public Transform left;
    public Transform right;
    public Transform pos;
    public bool back = false;
    private Movement movem;
    public Animation animate;
    public SpriteRenderer sprite;
    public Sprite[] skin;
    public float knockbackForce = 5f;

    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movem = FindObjectOfType<Movement>();
        animate = FindObjectOfType<Animation>();
        sprite = GetComponent<SpriteRenderer>();
        
        
        //dright.SetActive(true);
        //dleft.SetActive(false);
        //dup.SetActive(false);
        //ddown.SetActive(false);
    }
   public void FixedUpdate()
    {

        //animate = GetComponent<Animation>();
        if (target.position.x > transform.position.x )
        {
            sprite.sprite = skin[0];
            //dright.SetActive(true);
            //dleft.SetActive(false);
            //dup.SetActive(false);
            //ddown.SetActive(false);

        }
        else if (target.position.x < transform.position.x)
        {
            sprite.sprite = skin[1];
            //dright.SetActive(false);
            //dleft.SetActive(true);
            //dup.SetActive(false);
            //ddown.SetActive(false);

        }
        else if (target.position.y > transform.position.y )
        {
            sprite.sprite = skin[2];
            //dright.SetActive(false);
            //dleft.SetActive(false);
            //dup.SetActive(true);
            //ddown.SetActive(false);

        }
        else if (target.position.y < transform.position.y )
        {
            sprite.sprite = skin[3];
            //dright.SetActive(false);
            //dleft.SetActive(false);
            //dup.SetActive(false);
            //ddown.SetActive(true);

        }

        if (movem.chase == true && back == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 4 * Time.deltaTime);
           
        }



        if (back == true && movem.chase == false)
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
        if (collision.gameObject.CompareTag("Maximum"))
        {
            Debug.Log("Duta");
            back = true;
            movem.chase = false;

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
