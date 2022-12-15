using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NoiseHandeler : MonoBehaviour
{
    //private List<soundLevel>

    public List<GameObject> ListOfNoisemakers;
    public float soundLevelInRoom;
    private float soundLevelWhileInLoop;
    public Slider noiseSlider;
    public GameObject noiseEar;
    public SpriteRenderer green;
    public SpriteRenderer yellow;
    public SpriteRenderer red;
    public SpriteRenderer greenChild;
    public SpriteRenderer yellowChild;
    public SpriteRenderer redChild;



    private void Start()
    {
        noiseSlider.maxValue = 100;

    }

    // Update is called once per frame
    void Update()
    {
        //if (noiseSlider.value >= noiseSlider.maxValue)
        //{
        //    SceneManager.LoadScene("Meny");
        //}

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
            if (ListOfNoisemakers[i] != null)
            {
                IamMakingNoise iamMakingNoise = ListOfNoisemakers[i].GetComponent<IamMakingNoise>();
                soundLevelWhileInLoop += iamMakingNoise.levelOfSound;
            }

        }
        soundLevelInRoom = soundLevelWhileInLoop;
        soundLevelWhileInLoop = 0;
        //Adjusting visible slider to current noiselevel
        noiseSlider.value = soundLevelInRoom;


        if (soundLevelInRoom >= 1 && soundLevelInRoom < 33)
        {
            green.enabled = true;
            greenChild.enabled = true;

            red.enabled = false;
            redChild.enabled = false;
            yellow.enabled = false;
            yellowChild.enabled = false;
        }
        if (soundLevelInRoom >= 33 && soundLevelInRoom < 66)
        {
            yellow.enabled = true;
            yellowChild.enabled = true;
            green.enabled = true;
            greenChild.enabled = false;
            red.enabled = false;
            redChild.enabled = false;
        }

        if (soundLevelInRoom >= 66 && soundLevelInRoom < 100)
        {
            red.enabled = true;
            redChild.enabled = true;
            greenChild.enabled = false;
            yellowChild.enabled = false;
        }


        if (soundLevelInRoom == 0)
        {
            red.enabled = false;
            redChild.enabled = false;
            yellow.enabled = false;
            yellowChild.enabled = false;

            green.enabled = false;
            greenChild.enabled = false;

        }
    }
}
