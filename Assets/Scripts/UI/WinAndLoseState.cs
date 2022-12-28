using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinAndLoseState : MonoBehaviour
{
    public Slider noiseSlider;
    public SpriteRenderer fellOver;
    public SpriteRenderer toLoud;
    public SpriteRenderer winScreen;

    public GameObject progressionScreen;
    public Animator progressionAnimator;

    public PlayerController1 playerController;
    NoiseHandeler noiseHandeler;
    AllPlayerUpgradeables playerUpgrades;
    string sceneName;
    Scene currentScene;





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
        if (noiseHandeler.soundLevelInRoom >= 100 && swayBooksList.toMany == false && winScreen.enabled == false)
        {
            playerController.karinCantMove = true;
            playerController.inputAxis = new Vector2(0, 0);
            //playerController.enabled =false;

            toLoud.enabled = true;
            endTimer += Time.deltaTime;
            //shuting down the other win/fail conditions
            swayBooksList.toMany = false;

            if (endTimer > 15)
            {
                SceneManager.LoadScene("Meny");
            }
        }
        if (swayBooksList.toMany == true && toLoud.enabled == false && winScreen.enabled == false)
        {
            playerController.karinCantMove = true;
            playerController.inputAxis = new Vector2(0, 0);
            //playerController.enabled =false;

            endTimer += Time.deltaTime;

            if (endTimer > 4)
            {
                fellOver.enabled = true;

            }
            //shuting down the other win/fail conditions
            noiseSlider.value = 0;

            if (endTimer > 15)
            {
                SceneManager.LoadScene("Meny");

            }
        }
    }
    public void TimeIsUp()
    {
        bool endLock = false;
        playerController.karinCantMove = true;
        playerController.inputAxis = new Vector2(0, 0);
        //playerController.enabled =false;
        endTimer += Time.deltaTime;
        //shuting down the other win/fail conditions
        noiseSlider.value = 0;
        swayBooksList.toMany = false;
        if (fellOver.enabled == false && toLoud.enabled == false)
        {
            winScreen.enabled = true;


            if (endTimer > 10 && endLock == false)
            {
                Progression(SceneManager.GetActiveScene().buildIndex);
                endLock = true;


                //return if last scene
                //if (sceneName == "scene_main_2.3")
                //{
                //    SceneManager.LoadScene("Meny");
                //    return;
                //}
                // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
        }
    }


    //SceneManager.GetActiveScene().buildIndex;
    public void Progression(int level)
    {
        progressionScreen.SetActive(true);
        progressionAnimator.SetInteger("level", level);

    }

    public void NextScene()
    {
        //Temporary to not break level load
        //will soon be karin bathing 
        if (sceneName == "scene_main_2.3")
        {
            SceneManager.LoadScene("Meny");
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
