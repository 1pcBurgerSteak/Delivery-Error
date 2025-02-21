using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public static SceneManage instance;

    
    //void Awake()
    //{

    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }


    //}  
    public void ChangeScene(string sceneName)
    {
       
        SceneManager.LoadScene(sceneName);
       
    }
   
}
