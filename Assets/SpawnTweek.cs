using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnTweek : MonoBehaviour
{
    //random sprite book:

    //book chake efect:
    public Transform me;
    // Start is called before the first frame update
    void Start()
    {

        me = GetComponent<Transform>();
        //me.DOScale(2f, 0f);
        //me.DOScale(4f, 1f);
       // me.DOShakeScale(Random.Range(0.8f, 1.2f), 1f);

        me.DOShakeScale(1f, 0.6f);

    }

}
