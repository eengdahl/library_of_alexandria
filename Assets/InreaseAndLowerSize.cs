using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InreaseAndLowerSize : MonoBehaviour
{
    public float chargedHusch;
    public float chargedHuschMax;
    public float whenShake = 0.1f;

    MakeHuschSound makeHuschSoundScript;
    private void Start()
    {
        makeHuschSoundScript = FindObjectOfType<MakeHuschSound>();
    }

    // Update is called once per frame
    void Update()
    {
        chargedHusch = makeHuschSoundScript.chargedHush;
        chargedHuschMax = makeHuschSoundScript.chargedHuschMax;
        ScaleObject();
    }
    void ScaleObject()
    {
        if (Mathf.Abs(chargedHusch - chargedHuschMax) < whenShake)
        {
            float scale = 1 + Mathf.Sin(Time.time * 10) * whenShake;
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
