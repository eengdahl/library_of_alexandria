using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject overLay;
    SpriteRenderer overLaySprite;
    public static bool isGamePaused = false;
    [SerializeField] GameObject PauseMenunow;

    private void Awake()
    {
        overLaySprite = overLay.GetComponent<SpriteRenderer>();
        overLaySprite.enabled = false;
        Cursor.visible = false;
    }
    void Start()
    {
        
        //Cursor.visible = false;
    }
    void Update()
    {
        //if escape key was pressed switch to paused
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused == false)
            {
                Cursor.visible = true;
                PauseGame();
                overLaySprite.enabled = true;

            }
            else
            {
                Cursor.visible = false;
                ResumeGame();
                overLaySprite.enabled = false;
            }
        }  
    }
    public void ResumeGame()
    {
        PauseMenunow.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        isGamePaused = false;
        overLaySprite.enabled = false;
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
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        isGamePaused = false;
        //if (sceneName == "scene_main_julia") //if we are in tutorial
        //{
        //SceneManager.LoadScene("scene_main_julia");
        //Time.timeScale = 1f;
        //AudioListener.volume = 1f;
        //isGamePaused = false;
        //}

        //if (sceneName == "scene_main") //if we are in first lvl
        //{
        //SceneManager.LoadScene("scene_main");
        //Time.timeScale = 1f;
        //AudioListener.volume = 1f;
        //isGamePaused = false;
        //}

        //if (sceneName == "scene_main_Jovin")//if we are in fire scene
        //{
        //SceneManager.LoadScene("scene_main_Jovin");
        //Time.timeScale = 1f;
        //AudioListener.volume = 1f;
        //isGamePaused = false;  
        //}
    }
}

