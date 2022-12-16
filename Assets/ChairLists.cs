using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairLists : MonoBehaviour
{
    //Right side of map
    public GameObject[] chairsRightMiddle;
    public GameObject[] chairsRightLeft;
    public GameObject[] chairsRightRight;
    public List<GameObject[]> listOfRightChairArrays;
    //Left side of map
    public GameObject[] chairsLeftMiddle;
    public GameObject[] chairsLeftLeft;
    public GameObject[] chairsLeftRight;
    public List<GameObject[]> listOfLeftChairArrays;
    private void Start()
    {
        //Left
        listOfLeftChairArrays = new List<GameObject[]>();
        listOfLeftChairArrays.Add(chairsLeftMiddle);
        listOfLeftChairArrays.Add(chairsLeftRight);
        listOfLeftChairArrays.Add(chairsLeftLeft);

        //Right
        listOfRightChairArrays = new List<GameObject[]>();
        listOfRightChairArrays.Add(chairsRightMiddle);
        listOfRightChairArrays.Add(chairsRightRight);
        listOfRightChairArrays.Add(chairsRightLeft);


    }
}
