using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Meters : MonoBehaviour
{
    public Slider showTimeLeft;
    public Slider noiseMeter;
    private float timer;
    private int maxNoise = 100;

    private void Start()
    {
        noiseMeter.maxValue = 100;
    }


    void Update()
    {
        //Creating a timer and counting down from full time to no time 
        timer += Time.deltaTime;

        if (timer > 1)
        {
            showTimeLeft.value++;
            timer = 0;
            UpdateNoise(-5);
        }

        //testing so the noisemeter Reacts
        if (Input.GetButtonDown("Jump"))
        {
            UpdateNoise(10);
        }

    }


    //Function for very basic update of noisemeter
    public void UpdateNoise(int noise)
    {
        noiseMeter.value += noise;

        if (noiseMeter.value >= maxNoise)
        {
            SceneManager.LoadScene("Meny");
        }


    }
}
