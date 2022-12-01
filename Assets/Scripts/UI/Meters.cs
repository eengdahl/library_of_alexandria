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


    private void Start()
    {
  

    }


    void Update()
    {
        //Creating a timer and counting down from full time to no time 
        timer += Time.deltaTime;

        if (timer > 1)
        {

            showTimeLeft.value++;

            if (showTimeLeft.value >= showTimeLeft.maxValue)
            {
                SceneManager.LoadScene("Meny");
            }

            //Making noisemeter decreses always, NOT a good solution'
            //UpdateNoise(-8);

            timer = 0;
        }

    }


  
}
