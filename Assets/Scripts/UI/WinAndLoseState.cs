using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinAndLoseState : MonoBehaviour
{
    public Slider noiseSlider;
    public Slider timeSlider;
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
        if(timeSlider.value >= timeSlider.maxValue)
        {
            endTimer += Time.deltaTime;
            winScreen.enabled = true;
            if (endTimer > 10)
            {
                SceneManager.LoadScene("Meny");
            }
        }

        if (noiseSlider.value >= noiseSlider.maxValue)
        {
            endTimer += Time.deltaTime;
            toLoud.enabled = true;
            if (endTimer > 10)
            {
                SceneManager.LoadScene("Meny");
            }
        }
        if (swayBooksList.toMany == true)
        {
            endTimer += Time.deltaTime;
            fellOver.enabled = true;
            if (endTimer > 10)
            {
                SceneManager.LoadScene("Meny");
            }
        }
    }
}
