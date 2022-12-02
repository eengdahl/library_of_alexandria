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
    [SerializeField]float timer_between_NPCSpawns = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
       
        if (timer >= timer_between_NPCSpawns)
        {
            NPCPicker = Random.Range(0, standardNpcs.Length + 1);

            pickedNPC = standardNpcs[NPCPicker];
            SpawnNPC();
            timer = 0;
            
        }
    }

    public void SpawnNPC()
    {
        Instantiate(pickedNPC, transform.position,Quaternion.identity);
    }
}
