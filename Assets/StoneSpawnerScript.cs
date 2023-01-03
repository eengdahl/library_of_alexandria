using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject Stone;
    Vector3 spawnLocation;
    float timer;
    float timerEnd;
    void Start()
    {
        //timer = Random.Range(5, 20f);
        timerEnd = Random.Range(10f, 17f);
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timerEnd)
        {
            float x = Random.Range(-0.5f, 0.5f);
            float y = Random.Range(-0.5f, 0.5f);
            Vector3 location = new Vector3(x, y, 0);
            spawnLocation = transform.position + location;
            Instantiate(Stone, spawnLocation, transform.rotation);
            timerEnd = Random.Range(10f, 17f);
            timer = 0;
        }
    }
}
