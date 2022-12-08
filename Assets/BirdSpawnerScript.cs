using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawnerScript : MonoBehaviour
{
    float timeBetweenBirds;
    float timer;
    public GameObject bird;
    // Update is called once per frame

    private void Start()
    {
        timeBetweenBirds = Random.Range(20f, 65f);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeBetweenBirds)
        {
            timer = 0;
            SpawnBird();
        }
    }
    
    void SpawnBird()
    {
        timeBetweenBirds = Random.Range(20f, 65f);
        Instantiate(bird, transform.position, Quaternion.identity);
    }
}
