using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSingers : MonoBehaviour
{
    [Header("SingerPrefab")]
    [SerializeField] GameObject singer;
    [Header("Values")]
    [SerializeField]float spawnRate;
    public float timer;
    public int numberOfSingersSpawned;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnRate && numberOfSingersSpawned<=0)
        {
            numberOfSingersSpawned += 1;
            Instantiate(singer, transform.position, transform.rotation);
        }
    }
}
