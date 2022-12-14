using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOtherFire : MonoBehaviour
{
    public FireGrow fireGrowScript;
    public SpawnNewFires spawnNewFiresScript;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Destroy smaller fires in contact when fully grown
        if(collision.tag == "FireDestroyChecker" && fireGrowScript.isMaxSize == true )
        {
            spawnNewFiresScript.SpawnNewFire();
            Debug.Log("Fire Destroyed");
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
