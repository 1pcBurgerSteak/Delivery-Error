using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private SpawnTarget spawn;
    public bool canbe = false;

    
    
    public static Target instance;

  

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        spawn = GetComponent<SpawnTarget>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("duta");
            gameObject.SetActive(false);
            SpawnTarget.instance.delivered = true;
            SpawnTarget.instance.i = +1;
        }
    }
}
