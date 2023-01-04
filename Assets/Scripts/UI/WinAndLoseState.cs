using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class WinAndLoseState : MonoBehaviour
{
    public Slider noiseSlider;

    public SpriteRenderer fellOver;
    public GameObject fellOverButton;
    public SpriteRenderer toLoud;
    public GameObject toLoudButton;
    public SpriteRenderer winScreen;
    public SpriteRenderer winscreenbakground;

    public GameObject progressionScreen;
    public Animator progressionAnimator;

    public PlayerController1 playerController;
    NoiseHandeler noiseHandeler;
    AllPlayerUpgradeables playerUpgrades;
    string sceneName;
    Scene currentScene;

    int menuScene = 1;
    public AudioSource bookFellAS;
    public AudioSource tooLoudAS;
    public AudioSource winAS;




    bool playSoundOnce = true;


    float endTimer;
    SwayBooksList swayBooksList;
    private void Start()
    {
       
        playerUpgrades = FindObjectOfType<AllPlayerUpgradeables>();
        noiseHandeler = FindObjectOfType<NoiseHandeler>();
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        swayBooksList = FindObjectOfType<SwayBooksList>();
        playerController = FindObjectOfType<PlayerController1>();

    }
    private void Update()
    {
        if (noiseHandeler.soundLevelInRoom >= 80 && swayBooksList.toMany == false && winScreen.enabled == false)
        {
            playerController.karinCantMove = true;
            playerController.inputAxis = new Vector2(0, 0);
            //playerController.enabled =false;

            tooLoudAS.Play();

            toLoud.enabled = true;
            toLoudButton.SetActive(true);


            endTimer += Time.deltaTime;
            //shuting down the other win/fail conditions
            swayBooksList.toMany = false;


        }
        if (swayBooksList.toMany == true && toLoud.enabled == false && winScreen.enabled == false)
        {
            playerController.karinCantMove = true;
            playerController.inputAxis = new Vector2(0, 0);
            //playerController.enabled =false;

            endTimer += Time.deltaTime;

            if (endTimer > 4)
            {
                bookFellAS.Play();
                fellOver.enabled = true;
                fellOverButton.SetActive(true);

            }
            //shuting down the other win/fail conditions
            noiseSlider.value = 0;


        }
    }
    public void TimeIsUp()
    {
        playerController.karinCantMove = true;
        playerController.inputAxis = new Vector2(0, 0);
        //playerController.enabled =false;
        endTimer += Time.deltaTime;
        //shuting down the other win/fail conditions
        noiseSlider.value = 0;
        swayBooksList.toMany = false;
       // bool endLock = false;

        if (fellOver.enabled == false && toLoud.enabled == false)
        {
            PlayerPrefs.SetInt("levelCompleted", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.Save();
            if (playSoundOnce)
            {
                winAS.Play();
                playSoundOnce = false;
                AudioListener.volume = 0.1f;
            }
            winScreen.enabled = true;
            
            if ( winscreenbakground != null)
            {
            winscreenbakground.enabled = true;
            }
            winScreen.GetComponentInChildren<SpriteRenderer>().enabled = true;

            bool spacePressed = false;
            if (Input.GetKey("space"))
            {
                spacePressed = true;
            }
            if (endTimer > 10 || spacePressed)
            {
                winScreen.enabled = false;
                winScreen.GetComponentInChildren<SpriteRenderer>().enabled = false;
                Progression(SceneManager.GetActiveScene().buildIndex);
                spacePressed = false;

            }
           
        }
    }


    //SceneManager.GetActiveScene().buildIndex;
    public void Progression(int level)
    {
        //playerController.enabled = false;
        progressionScreen.SetActive(true);
        progressionAnimator.SetInteger("level", level);


    }

    public void NextScene()
    {
        //Temporary to not break level load
        //will soon be karin bathing 
        AudioListener.volume = 1f;
        if (sceneName == "scene_main_2.3")
        {
            SceneManager.LoadScene("TitleScreen");
            return;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        SceneManager.LoadScene(sceneName);
    }
}
