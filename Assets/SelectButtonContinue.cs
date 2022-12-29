using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButtonContinue : MonoBehaviour
{
    public Button continueButton;

  
    private void OnEnable()
    {
        continueButton.Select();
    }
}
