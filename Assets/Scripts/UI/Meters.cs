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
using System.Runtime.CompilerServices;

public class Meters : MonoBehaviour
{
    //public Slider noiseMeter;
    private float timer;
    public float timer2;
    public SpriteRenderer clock;
    public AudioSource clockAS;
    GameObject clockGame;
    public AudioClip lastTickOfClock;
    public Sprite[] clockpictures;
    private int timePast;
    public int maxTime;
    private float tickOfClock;
    WinAndLoseState winAndLoseState;
    NPCMovement nPCMovement;
    GameObject[] npc;
    public GameObject npcSpawner;
    //Scen2
    private void Start()
    {
        clock.sprite = clockpictures[0];
        tickOfClock = maxTime / clockpictures.Length;
        winAndLoseState = FindObjectOfType<WinAndLoseState>();
        nPCMovement = FindObjectOfType<NPCMovement>();

        clockGame = GameObject.FindGameObjectWithTag("Clock");
        if (clockGame != null)
        {
            clockAS = clockGame.GetComponent<AudioSource>();
        }

    }


    void Update()
    {
        //Creating a timer and counting down from full time to no time 
        timer += Time.deltaTime;

        if (timer > tickOfClock)
        {
            clockAS.Play();
            timePast++;
            bool clockLock = false;
            if (timePast >= clockpictures.Length - 1 && !clockLock)
            {
                LastTickOfClock();
                clockLock = true;

            }

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

    private void LastTickOfClock()
    {
        clockAS.clip = lastTickOfClock;
        clockAS.Play();
    }


}
