using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOG : MonoBehaviour
{
    public Transform target;
    public GameObject maximum;
    public GameObject minimum;
    public bool move = false;
    public Transform pos;
    public bool back = false;
   private  Movement movem;

     void Start()
    {
        movem = FindObjectOfType<Movement>();
    }
   public void FixedUpdate()
    {
        if (back == true && movem.chase == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos.position, 4 * Time.deltaTime);

            if (gameObject.transform.position == pos.transform.position)
            {
                gameObject.transform.position = pos.transform.position;
                back = false;
            }
        }


        if (movem.chase == true && back == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 4 * Time.deltaTime);
        }
    }
        

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Maximum"))
        {

            back = true;
            movem.chase = false;

        }


        
    }
}
