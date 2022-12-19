using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawn : MonoBehaviour
{
    //Stamina orb drop
    [SerializeField] GameObject staminaOrb;
    [SerializeField]BeingHusched beingHuschedScript;
    bool orbSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Instantiate the stamina orb
        if (beingHuschedScript.beingHusched == true && !orbSpawned)
        {
        Instantiate(staminaOrb, transform.position, transform.rotation);
            orbSpawned = true;
        }

    }
}
