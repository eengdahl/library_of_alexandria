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

    float endTimer;
    SwayBooksList swayBooksList;
    private void Start()
    {
        swayBooksList = FindObjectOfType<SwayBooksList>();
    }
    private void Update()
    {
        //if (timeSlider.value >= timeSlider.maxValue)
        //{
        //    endTimer += Time.deltaTime;
        //    winScreen.enabled = true;
        //    //shuting down the other win/fail conditions
        //    noiseSlider.value = 0;
        //    swayBooksList.toMany = false;

        //    if (endTimer > 10)
        //    {
        //        SceneManager.LoadScene("Meny");
        //    }
        //}

        if (noiseSlider.value >= noiseSlider.maxValue)
        {

            toLoud.enabled = true;
            endTimer += Time.deltaTime;
            //shuting down the other win/fail conditions
            swayBooksList.toMany = false;

            if (endTimer > 10)
            {
                SceneManager.LoadScene("Meny");
            }
        }
        if (swayBooksList.toMany == true)
        {
 
            endTimer += Time.deltaTime;
            fellOver.enabled = true;
            //shuting down the other win/fail conditions
            noiseSlider.value = 0;

            if (endTimer > 10)
            {
                SceneManager.LoadScene("Meny");
            }
        }
    }
    public void TimeIsUp()
    {
        endTimer += Time.deltaTime;
        winScreen.enabled = true;
        //shuting down the other win/fail conditions
        noiseSlider.value = 0;
        swayBooksList.toMany = false;

        if (endTimer > 10)
        {
            SceneManager.LoadScene("Meny");
        }
    }
}
