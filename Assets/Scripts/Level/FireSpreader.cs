using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Android;


public class FireSpreader : MonoBehaviour
{
    public GameObject fire;
    float timer;
    public List<GameObject> activeFires;
    private bool firstTime;
    public GameObject fireStarterPosition;
    public List<Vector3> firePositions;
    Vector3 lastPosition;
    int counter = 0;

    void Start()
    {
        firstTime = true;

    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10)
        {
            SpreadFire();
            timer = 0;
        }

    }


    public void SpreadFire()
    {
        

        if (firstTime)
        {
            Instantiate(fire, fireStarterPosition.transform.position, transform.rotation);
            activeFires.Add(fire);
            // firePositions.Add(activeFires[activeFires.Count-1].transform.position);

            firstTime = false;
            return;
        }
        for (int i = 0; i < 3; i++)
        {

            lastPosition = new Vector2(fireStarterPosition.transform.position.x - counter, fireStarterPosition.transform.position.y);
            //lastPosition = new Vector2((activeFires[i].transform.position.x - counter), activeFires[i].transform.position.y);


            Instantiate(fire, lastPosition, transform.rotation);
            activeFires.Add(fire);
            //firePositions.Add(activeFires[i].transform.position);

            counter++;

        }


        //    if (total == 0)
        //    {
        //        Instantiate(fire, transform.position, transform.rotation);
        //        activeFires.Add(fire);
        //        firePositions = new Vector3[activeFires.Count];



        //        total++;
        //        return;
        //    }
        //    else
        //    {

        //        lastPosition = firePositions[total];
        //        lastPosition.x--;
        //        //total++;
        //        Debug.Log("ping");
        //        Instantiate(fire, firePositions[activeFires.Count], transform.rotation);
        //        firePositions = new Vector3[activeFires.Count];
        //        activeFires.Add(fire);
        //    }


    }
}
