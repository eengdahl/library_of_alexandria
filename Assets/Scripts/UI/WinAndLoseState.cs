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
        if (swayBooksList.toMany == true&& toLoud.enabled == false && winScreen.enabled == false)
        {
            playerController.karinCantMove = true;
            playerController.inputAxis = new Vector2(0, 0);
            //playerController.enabled =false;

            endTimer += Time.deltaTime;

            if (endTimer>4)
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
            if (endTimer > 10)
            {
                if (sceneName == "scene_main_2.2")
                {
                    SceneManager.LoadScene("Meny");
                    return;
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                //if (sceneName == "scene_main_Jovin")
                //{
                //    SceneManager.LoadScene("Meny");
                //}
                ////SceneManager.LoadScene("Meny");
            }
        }
    }
}
