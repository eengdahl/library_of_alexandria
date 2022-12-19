using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHusched : MonoBehaviour
{
    public GameObject fireParent;
    FireGrow fireGrowScript;
    bool beingHusched;
    MakeHuschSound makeHuschSoundScriptPlayer;
    AudioSource aS;
    public AudioClip sorry;
    public bool fireIsHusched;
    private void Start()
    {
        makeHuschSoundScriptPlayer = FindObjectOfType<MakeHuschSound>();
        fireGrowScript = fireParent.GetComponent<FireGrow>();
        aS = GetComponentInParent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Husch" && makeHuschSoundScriptPlayer.doesHuschSound == true)
        {
            fireParent.transform.localScale = fireGrowScript.minSize;
            //aS.Play();
            fireIsHusched = true;        
        }
    }


}
