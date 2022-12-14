using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewFires : MonoBehaviour
{
    public GameObject firePrefab;
    FireGrow fireGrowScript;
    public float spawnDistance = 1;
    float timer;

    int firesSpawned = 0;
    public int maxFiresSpawned = 6;
    public bool canSpawn = true;
    private void Start()
    {
        fireGrowScript = GetComponent<FireGrow>();
    }
    private void Update()
    {
        if (fireGrowScript.isMaxSize == true && firesSpawned<maxFiresSpawned && canSpawn)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                firesSpawned += 1;
                SpawnNewFire();
                timer = 0;
            }
        }
    }



   public void SpawnNewFire()
    {
        Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
        Vector3 spawnPoint = transform.position + spawnDirection;
        Instantiate(firePrefab, spawnPoint, this.transform.rotation);
    }
}
