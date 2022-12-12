using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableStart : MonoBehaviour
{

    public List<Transform> moveToTableTransforms;
    public GameObject startOne;
    public GameObject startTwo;
    public GameObject startThree;
    public GameObject startFour;
    public GameObject startFive;
    public GameObject startSix;
    public GameObject startSeven;
    public GameObject startEight;

    private void Start()
    {
        moveToTableTransforms.Add(startOne.transform);
        moveToTableTransforms.Add(startTwo.transform);
        moveToTableTransforms.Add(startThree.transform);
        moveToTableTransforms.Add(startFour.transform);
        moveToTableTransforms.Add(startFive.transform);
        moveToTableTransforms.Add(startSix.transform);
        moveToTableTransforms.Add(startSeven.transform);
        moveToTableTransforms.Add(startEight.transform);
    }
}
