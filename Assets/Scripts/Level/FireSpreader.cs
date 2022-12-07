using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Android;


public class FireSpreader : MonoBehaviour
{
    public GameObject fire;
    float timer;
    public float spreadFireTimer;
    public List<GameObject> activeFires;
    public GameObject fireStarterPosition;
    public List<GameObject> firePositions;
    int counter = 0;


    private void Start()
    {
        spreadFireTimer = 1;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spreadFireTimer)
        {
            SpreadFire();
            timer = 0;
        }

    }


    public void SpreadFire()
    {
        //Can only spread if avalible spots open
        if (counter >= firePositions.Count)
        {
            return;
        }

        Instantiate(fire, firePositions[counter].transform.position, transform.rotation);
        activeFires.Add(fire);

        counter++;
        //Can only spread if avalible spots open

        if (counter % 3 == 0)
        {
            SpreadFire();
        }
        //if (counter >= firePositions.Count)
        //{
        //    return;
        //}

        ////adding more fire every third spawn
        //if (counter % 3 == 0)
        //{
        //    Instantiate(fire, firePositions[counter].transform.position, transform.rotation);
        //    activeFires.Add(fire);
        //    counter++;

        //}
    }
}
