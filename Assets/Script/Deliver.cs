using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deliver : MonoBehaviour
{
    public bool arrived = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            arrived = true;
            Destroy(gameObject);
        }
    }
}
