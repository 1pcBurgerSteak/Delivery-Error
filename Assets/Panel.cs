using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Panel : MonoBehaviour
{
    public Manager manager;
    void Start()
    {
        manager = FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        manager.NewGame();
    }
    public void Quit()
    {
        SceneManager.LoadScene(1);
    }


}
