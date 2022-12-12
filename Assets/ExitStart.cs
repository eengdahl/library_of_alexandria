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
    public GameObject exitFith;
    public GameObject exitSixth;
    public GameObject exitSeventh;
    public GameObject exitEight;
    private void Start()
    {

        //Needs to be added in same order as the arrays are sorted in order in waypoints armory script!!!!!
        exitTransforms.Add(exitOne.transform);
        exitTransforms.Add(exitTwo.transform);
        exitTransforms.Add(exitThree.transform);
        exitTransforms.Add(exitFour.transform);
        exitTransforms.Add(exitFith.transform);
        exitTransforms.Add(exitSixth.transform);
        exitTransforms.Add(exitSeventh.transform);
        //exitTransforms.Add(exitEight.transform);

    }
}
