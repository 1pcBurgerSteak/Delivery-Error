using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public GameObject Ufo;
    public Transform target;
    public Transform pos;
    public Transform[] position;
    public Transform[] tp;
    public bool back = false;
    public bool habol = false;
    public bool balik = true;
    public GameObject ilaw;


    void Start()
    {
        Ufo.transform.position = pos.position;
    }

    void Update()
    {
      
        Move();
        if (habol  && !back)
        {
            chase();
        }
        else
        {
            Move();
        }
        
    }
    public void Move()

    {
        if (Ufo.transform.position.x == position[0].position.x)
        {
            back = true;

        }
        else if (Ufo.transform.position.x == position[1].position.x)
        {
            back = false;

        }
        if (!back  && !habol)
        {
            Ufo.gameObject.transform.position = Vector3.MoveTowards(Ufo.gameObject.transform.position, position[0].position, 5 * Time.deltaTime);
        }
        else if (back  && !habol)
        {
            Ufo.gameObject.transform.position = Vector3.MoveTowards(Ufo.gameObject.transform.position, position[1].position, 5 * Time.deltaTime);
        }
        
    }

    public void chase()
    {
            Ufo.gameObject.transform.position = Vector3.MoveTowards(Ufo.gameObject.transform.position, target.position, 5 * Time.deltaTime);



    }
    //public void checker()
    //{
    //    if (Ufo.gameObject.transform.position.y == pos.position.y)
    //    {
    //        balik = true;
           
    //    }
    //    else
    //    {
    //        balik = false;
            
    //    }

   

//}

private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerMax"))
        {
            habol = true;
           
            back = false;

        }
        if (collision.gameObject.CompareTag("Player"))
        {
           
            habol = false;
           
            back = true;
            target.transform.position = tp[UnityEngine.Random.Range(0, tp.Length)].transform.position;
          
        }
        
    }

}
