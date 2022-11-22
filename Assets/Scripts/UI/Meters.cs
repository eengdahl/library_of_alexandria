using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Threading;

public class Meters : MonoBehaviour
{
    public Slider showTimeLeft;
    public Slider noiseMeter;
    private float timer;
    private float maxNoise = 100;
    private float test = 0f;

    private void Start()
    {
        noiseMeter.maxValue = maxNoise;
    }


    void Update()
    {
        //Creating a timer and counting down from full time to no time 
        timer += Time.deltaTime;

        if (timer > 1)
        {
            showTimeLeft.value++;

            if (showTimeLeft.value >= 300)
            {
                SceneManager.LoadScene("Meny");
            }

            //Making noisemeter decreses if no noise is present, NOT a good solution
            UpdateNoise(-2);

            timer = 0;
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
        // noiseMeter.value = Mathf.MoveTowards(noiseMeter.value, noise, 5);
        //noiseMeter.value = +Mathf.SmoothDamp(noiseMeter.value, noise, ref test, 1);

        // Takes input  from other objects and adds noise
        if (noise >= 0)
        {

            for (int i = 0; i < noise; i++)
            {
                //cant figure out how to make slider move smooth,
                noiseMeter.value++;
            }
        }
        //Takes input from other objects and decreses noise
        else if (noise < 0)
        {
            for (int i = 0; i < Mathf.Abs(noise); i++)
            {
                //cant figure out how to make slider move smooth,
                noiseMeter.value--;
            }
        }

        //if noisemeter reaches max, exit game
        if (noiseMeter.value >= maxNoise)
        {
            SceneManager.LoadScene("Meny");
        }


    }
}
