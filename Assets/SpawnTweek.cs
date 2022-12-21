using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnTweek : MonoBehaviour
{
    //random sprite book:
    private int rand;
    public Sprite[] Sprite_Pic;

    //book chake efect:
    public Transform me;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0,Sprite_Pic.Length);
        GetComponent<SpriteRenderer>().sprite = Sprite_Pic[rand];

        me = GetComponent<Transform>();
        //me.DOScale(2f, 0f);
        //me.DOScale(4f, 1f);
       // me.DOShakeScale(Random.Range(0.8f, 1.2f), 1f);

        me.DOShakeScale(1f, 0.6f);

    }

}
