using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public float staminaMax = 100;
    public float staminaMin = 0;
    public float stamina;
    public Slider staminaSlider;
    [SerializeField] Image fillImage;
    [SerializeField] Image bkgImage;
    
    private void Start()
    {
        staminaSlider.maxValue = staminaMax;
        stamina = staminaMin;
    }
    private void Update()
    {
        //Show stamina value in slider
        staminaSlider.value = stamina;
        if(stamina <= staminaMin)
        {
            stamina = staminaMin;
        }
        else if (stamina >= staminaMax)
        {
            stamina = staminaMax;

        }
        //if 0 stamina dont show slider
        if(staminaSlider.value <= 0)
        {
            bkgImage.enabled = false;
            fillImage.enabled = false;
        }
        else if (staminaSlider.value > 0)
        {
            bkgImage.enabled = true;
            fillImage.enabled = true;
        }

    }
}
