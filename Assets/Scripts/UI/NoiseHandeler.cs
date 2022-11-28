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
        CheckingNoise();
    }


    public void ÍAmMakingNoise(GameObject NPCMakingNoise)
    {

        ListOfNoisemakers.Add(NPCMakingNoise);


    }

    public void CheckingNoise()
    {
        for (int i = 0; i < ListOfNoisemakers.Count; i++)
        {
            IamMakingNoise iamMakingNoise = ListOfNoisemakers[i].GetComponent<IamMakingNoise>();
            soundLevelWhileInLoop += iamMakingNoise.levelOfSound;
            Debug.Log(soundLevelWhileInLoop);
        }
        soundLevelInRoom = soundLevelWhileInLoop;
        soundLevelWhileInLoop = 0;
        noiseSlider.value = soundLevelInRoom;
    }
}
