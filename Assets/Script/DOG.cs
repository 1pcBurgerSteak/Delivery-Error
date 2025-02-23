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
    public Transform up;
    public Transform down;
    public Transform pos;
    public bool back = false;
    private Movement movem;
    public Animator animate;
    public SpriteRenderer sprite;
    public Sprite[] skin;
    public float knockbackForce = 5f;
    public bool isup;
    public bool isdown;
    public bool isleft;
    public bool isright;
    private Rigidbody2D rb;
    private Manager manage;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movem = FindObjectOfType<Movement>();
        animate = FindObjectOfType<Animator>();
        animate = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        isup = false;
        isdown = false;
        isleft = false;
        isright = false;
        manage = FindObjectOfType<Manager>();
    //dright.SetActive(true);
    //dleft.SetActive(false);
    //dup.SetActive(false);
    //ddown.SetActive(false);
}
   public void FixedUpdate()
    {
        int baseLayer = 0;
        animate.SetLayerWeight(baseLayer, 1f);
        int move = animate.GetLayerIndex("goingleft");
        int movementLayer = animate.GetLayerIndex("goingright");
        int n = animate.GetLayerIndex("goingup");
        int nLayer = animate.GetLayerIndex("goingdown");

        if (isleft && !isright && !isup && !isdown)
        {
            animate.SetLayerWeight(n, 0f);
            animate.SetLayerWeight(nLayer, 0f);
            animate.SetLayerWeight(move, 1f);
            animate.SetLayerWeight(movementLayer, 0f);
        }
        else if (!isleft && isright && !isup && !isdown)
        {
            animate.SetLayerWeight(move, 0f);
            animate.SetLayerWeight(n, 0f);
            animate.SetLayerWeight(nLayer, 0f);
            animate.SetLayerWeight(movementLayer, 1f);
        }
        else if (!isleft && !isright && isup && !isdown)
        {
            animate.SetLayerWeight(move, 0f);
            animate.SetLayerWeight(n, 1f);
            animate.SetLayerWeight(nLayer, 0f);
            animate.SetLayerWeight(movementLayer, 0f);
        }
        else if (!isleft && !isright && !isup && isdown)
        {
            animate.SetLayerWeight(move, 0f);
            animate.SetLayerWeight(n, 0f);
            animate.SetLayerWeight(nLayer, 1f);
            animate.SetLayerWeight(movementLayer, 0f);
        }
        //animate = GetComponent<Animation>();
        if (target.position.x > right.position.x && target.position.y <= right.position.y)
        {
            isright = true;
            isleft = false;
            isup = false;
            isdown = false;
            
            //transform.rotation = Quaternion.Euler(0, 90, 0);
            //dright.SetActive(true);
            //dleft.SetActive(false);
            //dup.SetActive(false);
            //ddown.SetActive(false);
            Debug.Log("right");
        }
        else if (target.position.x < left.position.x && target.position.y <= left.position.y)
        {
            isright = false;
            isleft = true;
            isup = false;
            isdown = false;
           
            //transform.rotation = Quaternion.Euler(0, -90, 0);
            //dright.SetActive(false);
            //dleft.SetActive(true);
            //dup.SetActive(false);
            //ddown.SetActive(false);
            Debug.Log("left");

        }
        else if (target.position.y > up.position.y && target.position.x > up.position.x)
        {
            isright = false;
            isleft = false;
            isup = true;
            isdown = false;

            //transform.rotation = Quaternion.Euler(0, -90, 0);
            //dright.SetActive(false);
            //dleft.SetActive(true);
            //dup.SetActive(false);
            //ddown.SetActive(false);
            Debug.Log("left");

        }
        else if (target.position.y < down.position.y && target.position.x > down.position.x)
        {
            isright = false;
            isleft = false;
            isup = false;
            isdown = true;

            //transform.rotation = Quaternion.Euler(0, -90, 0);
            //dright.SetActive(false);
            //dleft.SetActive(true);
            //dup.SetActive(false);
            //ddown.SetActive(false);
            Debug.Log("left");

        }
        //else if (target.position.y > transform.position.y && isleft || target.position.y > transform.position.y && isright)
        //{
        //    //transform.rotation = Quaternion.Euler(-90, 0, 0);
        //    isup = true;
        //    //dright.SetActive(false);
        //    //dleft.SetActive(false);
        //    //dup.SetActive(true);
        //    //ddown.SetActive(false);
        //    Debug.Log("up");

        //}
        //else if (target.position.y < transform.position.y )
        //{
        //    //transform.rotation = Quaternion.Euler(90, 0, 0);
        //    int movementLayer = animate.GetLayerIndex("goingdown");
        //    animate.SetLayerWeight(movementLayer, 1f);
        //    //dright.SetActive(false);
        //    //dleft.SetActive(false);
        //    //dup.SetActive(false);
        //    //ddown.SetActive(true);
        //    Debug.Log("down");
        //}
        //transform.LookAt(target);

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
            manage.UpdateHealth(5);

            Debug.Log("health - 1");
            //Vector2 knockbackDirection = transform.position - collision.transform.position;
            //rb.AddForce(knockbackDirection.normalized * knockbackForce, ForceMode2D.Impulse);
        }
    }
}
