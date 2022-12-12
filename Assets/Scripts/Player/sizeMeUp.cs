using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeMeUp : MonoBehaviour
{
    float size;
    MakeHuschSound makeHuschSoundScript;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        makeHuschSoundScript = FindObjectOfType<MakeHuschSound>();

    }
    private void Update()
    {

        if(makeHuschSoundScript.chargedHush <= 0.35f)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.enabled = true;
        }
        size = makeHuschSoundScript.chargedHush+0.3f;

        transform.localScale = new Vector3(size, size, 0);
    }
}
