using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapQuickSelect : MonoBehaviour
{



    void Update()
    {
        if (Input.GetKeyDown("[7]"))
        {
            SceneManager.LoadScene("scene_main_julia");
        }
        if (Input.GetKeyDown("[8]"))
        {
            SceneManager.LoadScene("scene_main");
        }
        if (Input.GetKeyDown("[9]"))
        {
            SceneManager.LoadScene("scene_main_Jovin");
        }
    }
}
