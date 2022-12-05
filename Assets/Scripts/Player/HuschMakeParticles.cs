using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuschMakeParticles : MonoBehaviour
{
    public ParticleSystem dust;
    public MakeHuschSound makeHuschSoundScript;
    // Start is called before the first frame update
    private void Update()
    {
        if (makeHuschSoundScript.doesHuschSound == true)
        {
            CreateDust();
        }
        else if (makeHuschSoundScript.doesHuschSound == false)
        {
            dust.Stop();
        }
    }
    void CreateDust()
    {
        dust.Play();
    }
}
