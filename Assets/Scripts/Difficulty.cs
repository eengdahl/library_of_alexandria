using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{

    Meters meters;
    NPCMakeNoise nPCMakeNoise;
    NPCMovement nPCMovement;

    public int levelTime;
    public float levelSpeed;
    public int levelDificulty;
    public float spawnrateNPC;
    public int maxNPC;



    // Start is called before the first frame update
    void Start()
    {
        meters = FindObjectOfType<Meters>();
        nPCMakeNoise = FindObjectOfType<NPCMakeNoise>();
        nPCMovement = FindObjectOfType<NPCMovement>();




        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "scene_main_julia")
        {
            Tutorial();
        }


        if (sceneName == "scene_main" || sceneName == "scene_main_emil"  || sceneName == "scene_main_Jovin" || sceneName == "scene_main_wildandfun")
        {
            Level1();
        }


        if (sceneName == "scene_main_1.0")
        {
            Level1();
        }

        if (sceneName== "scene_main_1.1")
        {
            Level2();
        }
    }



    void Level1()
    {
        //Standard valuees for all stats
        SetTimeOfLevel(120);
        SetNPCNoiseChance(9);
        SetNPCMovespeed(1.25f);
        MaxNPCOnMap(14);
        SpawnRateNPC(3);
    }

    void Level2()
    {
        SetTimeOfLevel(120);
        SetNPCNoiseChance(9);
        SetNPCMovespeed(1.25f);
        MaxNPCOnMap(17);
        SpawnRateNPC(3);
    }
    void Tutorial()
    {
        SetTimeOfLevel(9999999);
       // SetNPCNoiseChance(9);
       // SetNPCMovespeed(1.25f);
        MaxNPCOnMap(0);
      //  SpawnRateNPC(3);
    }


    public void SetTimeOfLevel(int time)
    {
        levelTime = time;   
        meters.maxTime = time;
    }


    //Standard diff is 10, less is harder 
    public void SetNPCNoiseChance(int difficulty)
    {
        levelDificulty = difficulty;
        nPCMakeNoise.npcNoiseDifficulty = difficulty;
    }


    //Speed is standard 1.7f
    public void SetNPCMovespeed(float speed)
    {
        levelSpeed = speed;
        nPCMovement.moveSpeed = speed;
    }

    public void MaxNPCOnMap(int maxNPCCount)
    {
        maxNPC = maxNPCCount;
    }

    public void SpawnRateNPC(int timeBetweenSpawns)
    {
        spawnrateNPC = timeBetweenSpawns;
    }
}

