using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    [SerializeField] GameObject PauseMenunow;
    
    void Start()
    {
        
    }
    void Update()
    {
        //if escape key was pressed switch to paused
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused == false)
            {   
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }  
    }
    public void ResumeGame()
    {
        PauseMenunow.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        isGamePaused = false;
    }

    void PauseGame()
    {
        PauseMenunow.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.volume = 0f;
        isGamePaused = true;
    }

    public void LoadMenu()
    {
        PauseMenunow.SetActive(false);
        SceneManager.LoadScene("Meny");
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        isGamePaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("JULIA");
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        isGamePaused = false;
    }
}

