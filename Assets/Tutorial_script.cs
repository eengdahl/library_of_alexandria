using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_script : MonoBehaviour
{
    [SerializeField] GameObject Stop_NPC_Spawn;
    public GameObject[] standardNpcs;
    //public GameObject firstNPC;
    //public GameObject secondNPC;
    GameObject pickedNPC;
    int NPCPicker = 0;
    float timer;
    float spawOneTime = 0;
    [SerializeField]float timer_between_NPCSpawns = 5f;
    // Start is called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
        Stop_NPC_Spawn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //(for the moment)when p is pressed tarts the npc spawner
        if (Input.GetKeyDown("p"))
        {
            Stop_NPC_Spawn.SetActive(true);
        }
        if (Input.GetKeyDown("o"))
        {
            Stop_NPC_Spawn.SetActive(false);
        }

        if (timer >= timer_between_NPCSpawns && spawOneTime == 0 )
        {
            NPCPicker = 1;

            pickedNPC = standardNpcs[NPCPicker];
           
            SpawnNPC();
            timer = 0;
            spawOneTime = 1;
        } 
        timer += Time.deltaTime;
    }
    public void SpawnNPC()
    {
        Instantiate(pickedNPC, transform.position,Quaternion.identity);
    }
}
