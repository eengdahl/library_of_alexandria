using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnerscript : MonoBehaviour
{
    public GameObject firstNPC;

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
        Debug.Log(timer);
        if (timer >= timer_between_NPCSpawns)
        {
            SpawnNPC();
            timer = 0;
            Debug.Log(timer);
        }
    }

    public void SpawnNPC()
    {
        Instantiate(firstNPC, transform.position,Quaternion.identity);
    }
}
