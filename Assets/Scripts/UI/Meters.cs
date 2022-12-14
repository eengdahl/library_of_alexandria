using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Threading;
using Unity.VisualScripting;

public class Meters : MonoBehaviour
{
    //public Slider noiseMeter;
    private float timer;
    public float timer2;
    public SpriteRenderer clock;
    public Sprite[] clockpictures;
    private int timePast;
    private int maxTime;
    private float tickOfClock;
    WinAndLoseState winAndLoseState;
    NPCMovement nPCMovement;
    GameObject[] npc;
    public GameObject npcSpawner;

    private void Start()
    {

        maxTime = 180;
        clock.sprite = clockpictures[0];
        tickOfClock = maxTime / clockpictures.Length;
        winAndLoseState = FindObjectOfType<WinAndLoseState>();
        nPCMovement = FindObjectOfType<NPCMovement>();


    }


    void Update()
    {
        //Creating a timer and counting down from full time to no time 
        timer += Time.deltaTime;

        if (timer > tickOfClock)
        {

            timePast++;

            if (timePast >= clockpictures.Length)
            {
                SearchForAllNPC();
                winAndLoseState.TimeIsUp();



                return;
            }
            clock.sprite = clockpictures[timePast];
            timer = 0;
        }

    }

    //making all npc leav room when level is done 
    public void SearchForAllNPC()
    {
        npcSpawner.SetActive(false);

        var NPCs = GameObject.FindGameObjectsWithTag("NPC");
        for (int i = 0; i < NPCs.Length; i++)
        {
            NPCs[i].GetComponent<NPCMovement>().isLeaving = true;
            NPCs[i].GetComponent<Animator>().SetBool("isLeaving", true);
        }

    }



}
