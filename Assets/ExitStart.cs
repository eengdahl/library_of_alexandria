using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitStart : MonoBehaviour
{
    public List<Transform> exitTransforms;
    public GameObject exitOne;
    public GameObject exitTwo;
    public GameObject exitThree;
    public GameObject exitFour;
    private void Start()
    {

        //Needs to be added in same order as the arrays are sorted in order in waypoints armory script!!!!!
        exitTransforms.Add(exitOne.transform);
        exitTransforms.Add(exitTwo.transform);
        exitTransforms.Add(exitThree.transform);
        exitTransforms.Add(exitFour.transform);
    }
}
