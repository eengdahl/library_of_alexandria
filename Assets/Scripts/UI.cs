using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    public Slider showTimeLeft;
    public Slider noiseMeter;
    public float timer = 300f;
    float noNoise = 5f;


    // Update is called once per frame
    void Update()
    {
        //Creating a timer and counting down from full time to no time 
        timer = timer - Time.deltaTime;
        showTimeLeft.value = timer;

        //testing so the noisemeter Reacts
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Ping");
            UpdateNoise(1);
        }
    }


    //Function for very basic update of noisemeter
    public void UpdateNoise(int noise)
    {
      


        noiseMeter.value += noise;

        if (true)
        {

        }
    }
}
