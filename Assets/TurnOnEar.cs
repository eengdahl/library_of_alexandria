using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnOnEar : MonoBehaviour
{
    [SerializeField] GameObject Ear;
    void Start()
    {
        PlayerPrefs.SetInt("levelCompleted", SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.Save();
        Ear.SetActive(true);
    }


}
