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


    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;
        showTimeLeft.value = timer;

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Ping");
            UpdateNoise(10);
        }
    }


    public void UpdateNoise(int noise)
    {
        noiseMeter.value += noise;

        if (true)
        {

        }
    }
}
