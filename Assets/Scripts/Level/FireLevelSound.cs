using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireLevelSound : MonoBehaviour
{

    AudioSource aS;
    public AudioClip fire;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Scene_Fire")
        {
            aS = GetComponent<AudioSource>();
            aS.clip = fire;
            aS.loop = true;
            aS.Play();
        }
    }

 
}
