using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeMeUp : MonoBehaviour
{
    //float size;
    MakeHuschSound makeHuschSoundScript;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        makeHuschSoundScript = FindObjectOfType<MakeHuschSound>();

    }
    private void Update()
    {


        //gameObject.transform.localScale = makeHuschSoundScript.gameObject.transform.localScale;
        if (makeHuschSoundScript.chargedHush <= 0)//.chargedHush
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.enabled = true;
        }
        //size = makeHuschSoundScript.chargedHush + 0.3f;

        //transform.localScale = new Vector3(size, size, 0);
    }
}
