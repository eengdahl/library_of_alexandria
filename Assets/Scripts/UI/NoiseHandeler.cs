using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NoiseHandeler : MonoBehaviour
{
    //private List<soundLevel>

    public List<GameObject> ListOfNoisemakers;
    public float soundLevelInRoom;
    private float soundLevelWhileInLoop;
    public Slider noiseSlider;





    // Update is called once per frame
    void Update()
    {
        noiseSlider.maxValue = 300000;
        //Checking over all noise
        CheckingNoise();
    }


    public void IAmMakingNoise(GameObject NPCMakingNoise)
    {
        //Called from NPCs making noise
        ListOfNoisemakers.Add(NPCMakingNoise);


    }

    public void CheckingNoise()
    {
        //Going through NPCs making noise and adding theire current noiselevel
        for (int i = 0; i < ListOfNoisemakers.Count; i++)
        {
            IamMakingNoise iamMakingNoise = ListOfNoisemakers[i].GetComponent<IamMakingNoise>();
            soundLevelWhileInLoop += iamMakingNoise.levelOfSound;
        }
        soundLevelInRoom = soundLevelWhileInLoop;
        soundLevelWhileInLoop = 0;
        //Adjusting visible slider to current noiselevel
        noiseSlider.value = soundLevelInRoom;
    }
}
