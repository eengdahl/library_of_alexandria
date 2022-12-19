using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayerUpgradeables : MonoBehaviour
{
    //MaxStamina increase
    Stamina staminaScript;
    //BigHusch radius increase
    MakeHuschSound makeHuschSoundScript;
    //Antal inventory slots
    public int numberOfSlot = 6;
    public float staminaMax;
    public float normalSpeed;
    public float sprintSpeed;
    public float pickUpMagnetRadius;
    //Magnetic pick up radius
    //Huschpondus, increases all npcs time before they make noise again
    public float pondusLevel;
    public float chargedHuschMax;
    public int chanceOfSpawningOrbs;
    //Magnet size
    [SerializeField] CircleCollider2D magnetArea;


    // Start is called before the first frame update
    void Start()
    {
        pondusLevel = 1;
        makeHuschSoundScript = FindObjectOfType<MakeHuschSound>();
        staminaScript = FindObjectOfType<Stamina>();
    }

    // Update is called once per frame
    void Update()
    {
        magnetArea.radius = pickUpMagnetRadius;
        if (Input.GetKeyDown(KeyCode.G))
        {
            makeHuschSoundScript.chargedHuschMax += 0.3f;
            magnetArea.radius += 0.1f;
            pondusLevel += 1;
        }

        if (Input.GetKeyDown(KeyCode.X)) // example for how to upgrade stamina
        {
            staminaScript.staminaMax += 20;
            staminaScript.staminaSlider.maxValue += 20;
        }
    }
}
