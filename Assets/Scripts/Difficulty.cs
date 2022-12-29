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
    void Awake()
    {
        meters = FindObjectOfType<Meters>();
        nPCMakeNoise = FindObjectOfType<NPCMakeNoise>();
        nPCMovement = FindObjectOfType<NPCMovement>();




        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "scene_main_julia" || sceneName == "Scene_tutorial")
        {
            Tutorial();
        }


        if (sceneName == "scene_main" || sceneName == "scene_main_emil" || sceneName == "scene_main_Jovin" || sceneName == "scene_main_wildandfun")
        {
            Level1();
        }


        if (sceneName == "scene_main_1.0")
        {
            Level1();
        }

        if (sceneName == "scene_main_1.1")
        {
            Level2();
        }

        if (sceneName == "scene_main_1.2")
        {
            Level3();
        }

        if (sceneName == "scene_main_2.0")
        {
            Level4();
        }

        if (sceneName == "scene_main_2.1")
        {
            Level5();
        }
        if (sceneName == "scene_main_2.2")
        {
            Level6();
        }
        if (sceneName == "scene_main_2.3")
        {
            Level7();
        }
    }



    void Level1()
    {
        //Standard valuees for all stats
        SetTimeOfLevel(120);
        SetNPCNoiseChance(9);
        SetNPCMovespeed(1.25f);
        MaxNPCOnMap(14);
        SpawnRateNPC(4);
    }

    void Level2()
    {
        SetTimeOfLevel(120);
        SetNPCNoiseChance(9);
        SetNPCMovespeed(1.25f);
        MaxNPCOnMap(17);
        SpawnRateNPC(3);
    }

    void Level3()
    {
        SetTimeOfLevel(160);
        SetNPCNoiseChance(8);
        SetNPCMovespeed(1.25f);
        MaxNPCOnMap(25);
        SpawnRateNPC(5);
    }

    void Level4()
    {
        SetTimeOfLevel(190);
        SetNPCNoiseChance(8);
        SetNPCMovespeed(1.4f);
        MaxNPCOnMap(17);
        SpawnRateNPC(3);
    }

    void Level5()
    {
        SetTimeOfLevel(140);
        SetNPCNoiseChance(8);
        SetNPCMovespeed(1.4f);
        MaxNPCOnMap(15);
        SpawnRateNPC(3);
    }

    void Level6()
    {
        SetTimeOfLevel(110);
        SetNPCNoiseChance(5);
        SetNPCMovespeed(1.4f);
        MaxNPCOnMap(12);
        SpawnRateNPC(4);
    }

    void Level7()
    {
        SetTimeOfLevel(10);
        SetNPCNoiseChance(7);
        SetNPCMovespeed(1.4f);
        MaxNPCOnMap(30);
        SpawnRateNPC(4);
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

