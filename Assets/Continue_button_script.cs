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
    [SerializeField] GameObject shadow;
    [SerializeField] Animator EndBookAnimator; 
    
    public void Continue()
    {
        shadow.SetActive(false);
        clockPicture.SetActive(true);
        EndBookAnimator.SetBool("TurnPage", true);
        if (counter >= 1)
        {
            SceneManager.LoadScene("scene_main_1.0");
        }
        counter++;
    }
}
