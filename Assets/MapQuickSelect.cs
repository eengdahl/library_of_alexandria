using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapQuickSelect : MonoBehaviour
{



    void Update()
    {
        if (Input.GetKeyDown("3"))
        {
            SceneManager.LoadScene("scene_tutorial");
        }
        if (Input.GetKeyDown("4"))
        {
            SceneManager.LoadScene("scene_main_1.0");
        }
        if (Input.GetKeyDown("5"))
        {
            SceneManager.LoadScene("scene_main_1.1");
        }
        if (Input.GetKeyDown("6"))
        {
            SceneManager.LoadScene("scene_main_1.2");
        }
        if (Input.GetKeyDown("7"))
        {
            SceneManager.LoadScene("scene_main_2.0");
        }
        if (Input.GetKeyDown("8"))
        {
            SceneManager.LoadScene("scene_main_2.1");
        }
        if (Input.GetKeyDown("9"))
        {
            SceneManager.LoadScene("scene_main_2.2");
        }
    }
}
