using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    private bool isPlayerAlive = true;

    private void Start()
    {
        pauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (isPlayerAlive)
        {
            Time.timeScale = 0f;
            TogglePauseUI(true);
        }
        
    }

    public void ResumeGame()
    {

        if (isPlayerAlive)
        {
            Time.timeScale = 1f;
            TogglePauseUI(false);
        }
        
    }

    public void TogglePauseUI(bool isPaused)
    {
        pauseUI.SetActive(isPaused);
    }

    public void SetPlayerAlive(bool alive)
    {
        isPlayerAlive = alive;
    }
}