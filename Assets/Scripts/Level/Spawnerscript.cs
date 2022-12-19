using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnerscript : MonoBehaviour
{
    public GameObject[] standardNpcs;
    //public GameObject firstNPC;
    //public GameObject secondNPC;
    GameObject pickedNPC;
    int NPCPicker = 0;
    float timer;
    [SerializeField] float timer_between_NPCSpawns = 5f;

    Difficulty difficulty;

    public int maxNPC_;
    float spawnRate;
    void Start()
    {
        difficulty = FindObjectOfType<Difficulty>();

        maxNPC_ = difficulty.maxNPC;
        spawnRate = difficulty.spawnrateNPC;


        InvokeRepeating("SerchForNPC", 5f, spawnRate) ;

    }

    //// Update is called once per frame
    //void Update()
    //{







    //    timer += Time.deltaTime;

    //    if (timer >= timer_between_NPCSpawns)
    //    {
    //        timer = 0;
    //        SpawnNPC();

    //    }
    //}

    public void SerchForNPC()
    {
        var NPCs = GameObject.FindGameObjectsWithTag("NPC");

        if (NPCs.Length < maxNPC_)
        {
            SpawnNPC();
            Debug.Log("spawn");
        }
    }
    public void SpawnNPC()
    {
        NPCPicker = Random.Range(0, standardNpcs.Length);
        pickedNPC = standardNpcs[NPCPicker];

        Instantiate(pickedNPC, transform.position, Quaternion.identity);

    }


}
