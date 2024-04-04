using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("Level01");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Tutorial2()
    {
        SceneManager.LoadScene("Tutorial2");
    }

    public void Tutorial3()
    {
        SceneManager.LoadScene("Tutorial3");
    }

    public void Tutorial4()
    {
        SceneManager.LoadScene("Tutorial4");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
