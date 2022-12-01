using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Numerics;

public class InventoryUI : MonoBehaviour
{
    public Transform myTransform;

    public float endPosY = 5f;
    private float startPosY;
    public bool hidden;

    // Start is called before the first frame update
    void Start()
    {
        hidden = true;
        myTransform = transform;

    }

    // Update is called once per frame
    void Update()
    {
        if ( hidden == true)
        {
            transform.DOMoveY(startPosY, 0.5f).OnComplete(Complete).SetEase(Ease.OutBounce);
        }
        if ( hidden == false)
        {
            transform.DOMoveY(endPosY, 0.5f).OnComplete(Complete).SetEase(Ease.InBounce);
        }
    }

    void Complete()
    {
        hidden = !hidden;
    }
}
