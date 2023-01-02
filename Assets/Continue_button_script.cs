using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue_button_script : MonoBehaviour
{
    public GameObject Button;
    int counter = 0;
    public GameObject clockPicture;


    public void Continue()
    {
        clockPicture.SetActive(true);
        if (counter >= 1)
        {
            SceneManager.LoadScene("scene_main_1.0");
        }
        counter++;
    }
}
