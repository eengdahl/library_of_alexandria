using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawn : MonoBehaviour
{
    //Stamina orb drop
    [SerializeField] GameObject staminaOrb;
    [SerializeField]BeingHusched beingHuschedScript;
    bool orbSpawned = false;
    AllPlayerUpgradeables playerUpgradeables;
    int randomNumber;
    // Start is called before the first frame update
    void Start()
    {
        playerUpgradeables = FindObjectOfType<AllPlayerUpgradeables>();
        randomNumber = Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        //Instantiate the stamina orb
        if (beingHuschedScript.beingHusched == true && !orbSpawned)
        {
            if( playerUpgradeables.chanceOfSpawningOrbs > randomNumber)
            {
            Instantiate(staminaOrb, transform.position, transform.rotation);
            orbSpawned = true;

            }
        }

    }
}
