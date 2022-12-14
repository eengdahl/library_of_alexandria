using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHusched : MonoBehaviour
{
    public GameObject fireParent;
    FireGrow fireGrowScript;
    bool beingHusched;
    MakeHuschSound makeHuschSoundScriptPlayer;
    private void Start()
    {
        makeHuschSoundScriptPlayer = FindObjectOfType<MakeHuschSound>();
        fireGrowScript = fireParent.GetComponent<FireGrow>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Husch" && makeHuschSoundScriptPlayer.doesHuschSound == true)
        {
            fireParent.transform.localScale = fireGrowScript.minSize;          
        }
    }
}