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
    public TMP_Text fellOver;
    public TMP_Text toLoud;
    public TMP_Text youWon;
    public Meters meters;
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
            youWon.enabled = true;
            if (endTimer > 5)
            {
                SceneManager.LoadScene("Meny");
            }
        }

        if (noiseSlider.value >= noiseSlider.maxValue)
        {
            endTimer += Time.deltaTime;
            toLoud.enabled = true;
            if (endTimer > 5)
            {
                SceneManager.LoadScene("Meny");
            }
        }
        if (swayBooksList.toMany == true)
        {
            endTimer += Time.deltaTime;
            fellOver.enabled = true;
            if (endTimer > 5)
            {
                SceneManager.LoadScene("Meny");
            }
        }
    }
}
