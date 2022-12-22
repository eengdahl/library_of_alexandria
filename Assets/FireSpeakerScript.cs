using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireSpeakerScript : MonoBehaviour
{
    AudioSource aS;
    string sceneName;
    Scene currentScene;
    // Start is called before the first frame update
    void Start()
    {

        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (sceneName == "scene_main_2.2"|| sceneName == "scene_main_2.1"|| sceneName == "scene_main_2.0")
        {
            aS = GetComponent<AudioSource>();
            aS.Play();
        }
    }

  
}
