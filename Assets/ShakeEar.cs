using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeEar : MonoBehaviour
{
    Shake shakeScript;
    NoiseHandeler noiseHandelerScript;
    public bool superRedBool;
    public bool shouldShakeYellow = true;
    bool shouldShakeRed = true;
    // Start is called before the first frame update
    void Start()
    {
        shakeScript = GetComponent<Shake>();
        noiseHandelerScript = FindObjectOfType<NoiseHandeler>();
    }

    // Update is called once per frame
    void Update()
    {
        superRedBool = ResetShake(100, superRedBool);
        shouldShakeYellow = ShakeDaBooty(shouldShakeYellow,20);
        shouldShakeYellow = ResetShake(20, shouldShakeYellow);
        shouldShakeRed = ResetShake(66, shouldShakeRed);
        shouldShakeRed = ShakeDaBooty(shouldShakeRed,66);

        if(noiseHandelerScript.soundLevelInRoom > 80)
        {
            shakeScript.StartShake(0.1f, 0.3f, this.transform.position, 0.05f);
        }
        


        //if (noiseHandelerScript.soundLevelInRoom > 20 &&  shouldShakeYellow) // noiseHandelerScript.soundLevelInRoom <= 22 &&
        //{
        //    shakeScript.StartShake(2, 0.1f, this.transform.position, 0.05f);
        //    shouldShakeYellow = false;
        //}
    }
    private bool ResetShake(int resetValue,bool colourBool)
    {
        if (noiseHandelerScript.soundLevelInRoom < resetValue && colourBool == false)
        {
            Debug.Log("Should reset bool");
            return colourBool = true;
        }
        else
        {
            return colourBool;
        }
    }
    private bool ShakeDaBooty(bool colourBool,int levelOfSound)
    {
        if (noiseHandelerScript.soundLevelInRoom > levelOfSound && colourBool) // noiseHandelerScript.soundLevelInRoom <= 22 &&
        {
            shakeScript.StartShake(1, 0.1f, this.transform.position, 0.05f);
            return colourBool = false;
        }
        else
        {
            return colourBool;
        }

    }
}
