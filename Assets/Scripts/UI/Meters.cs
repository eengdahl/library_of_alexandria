using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Threading;
using Unity.VisualScripting;

public class Meters : MonoBehaviour
{
    public Slider showTimeLeft;
    //public Slider noiseMeter;
    private float timer;
    public float timer2;
    private float maxNoise = 300;
    private float noiseBuffer;

    private void Start()
    {
       // noiseMeter.maxValue = maxNoise;

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

            //Making noisemeter decreses always, NOT a good solution'
            //UpdateNoise(-8);

            timer = 0;
        }

    }


    //Function for very basic update of noisemeter
    //public void UpdateNoise(int noise)
    //{
    //    //Saving all input in buffer and resets every run. 
    //    //This nr can reach 4000ish  and is a bit buggy
    //    noiseBuffer += noise;

    
    //    if (timer > 1f)
    //    {
      

    //        // Takes input  from other objects and adds noise
    //        if (noiseBuffer > 0)
    //        {
    //            noiseMeter.value += 10;
    //        }
    //        //Takes input from other objects and decreses noise
    //        else if (noiseBuffer <= 0)
    //        {
    //            //cant figure out how to make slider move smooth,
    //            noiseMeter.value += -5;

    //        }

    //        //if noisemeter reaches max, exit game
    //        if (noiseMeter.value >= maxNoise)
    //        {

    //            Debug.Log("MaxNoise");
    //            // SceneManager.LoadScene("Meny");
    //        }
    //        noiseBuffer = 0;
    //        timer = 0;
    //    }

    //    // noiseMeter.value = Mathf.MoveTowards(noiseMeter.value, noise, 5);
    //    //noiseMeter.value = +Mathf.SmoothDamp(noiseMeter.value, noise, ref test, 1);

    //}
}
