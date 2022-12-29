using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButtonRetry : MonoBehaviour
{
    public Button retryButton;


    private void OnEnable()
    {
        retryButton.Select();
    }
}
