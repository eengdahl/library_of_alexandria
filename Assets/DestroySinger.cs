using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySinger : MonoBehaviour
{
    public bool canBeDestroyed = false;
    SpawnSingers spawnSingersScript;
    GameObject spawnSinger;
    private void Start()
    {
        spawnSinger = GameObject.FindGameObjectWithTag("SingerDestroyPoint");     
        spawnSingersScript = spawnSinger.GetComponent<SpawnSingers>();
    }
    void Update()
    {
        if (canBeDestroyed && transform.position.y < -5.9f)
        {
            spawnSingersScript.timer = 0;
            spawnSingersScript.numberOfSingersSpawned -= 1;
            Destroy(gameObject);
        }
    }
}
