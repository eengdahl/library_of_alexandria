using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RedLightTurnOnOff : MonoBehaviour
{
    public NoiseHandeler noiseHandlerScript;
    public GameObject redLight;
    float timer;
    bool activated = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(noiseHandlerScript.soundLevelInRoom > 90)
        {
            
            timer += Time.deltaTime;
            if (timer > 0.5)
            {
                activated = !activated;
                redLight.SetActive(activated);
                timer = 0;
            }
        }
        else
        {
            redLight.SetActive(false);
        }
    }
}
