using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectButtonCredit : MonoBehaviour
{
    public Button menyButton;
    private void OnEnable()
    {
        menyButton.Select();

    }

}
