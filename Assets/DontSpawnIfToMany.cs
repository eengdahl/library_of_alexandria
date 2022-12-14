using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontSpawnIfToMany : MonoBehaviour
{
    Collider2D collider;
    List<GameObject> otherFires;
    public SpawnNewFires spawnNewFiresScript;
    public int toMany = 3;
    void Start()
    {
        collider = GetComponent<Collider2D>();
        otherFires = new List<GameObject>();
    }


    void Update()
    {
        if (otherFires.Count >= toMany)
        {
            Debug.Log("Dont spawn");
            spawnNewFiresScript.canSpawn = false;
            collider.enabled = false;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "FireDestroy" && spawnNewFiresScript.canSpawn == true)
        {
            if (otherFires.IndexOf(collision.gameObject) < 0)
            {
            otherFires.Add(collision.gameObject);

            }
        }
    }
}
