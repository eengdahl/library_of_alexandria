using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ProgressionScript : MonoBehaviour
{

    // public Button retryButton;
    // public Button continueButton;
    public GameObject retryButton;
    public GameObject continueButton;
    public Animator me;

    private void Awake()
    {
        me = GetComponent<Animator>();
    }

    public void AcvtivateButtons()
    {
        me.SetInteger("level", 1);
        retryButton.SetActive(true);
        continueButton.SetActive(true);
    }
}
