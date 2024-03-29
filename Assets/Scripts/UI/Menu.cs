using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject ButtonPanelOnOff;
    public GameObject CreditsOnOff;
    public GameObject SettingsOnOff;
    public Button start;

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void StartGame()
    {
        SceneManager.LoadScene("scene_tutorial");
    }

    public void Credits()
    {
        ButtonPanelOnOff.SetActive(false);
        CreditsOnOff.SetActive(true);

    }

    public void MainMenu()
    {
        ButtonPanelOnOff.SetActive(true);
        CreditsOnOff.SetActive(false);
        start.Select();
    }

    public void Settings()
    {
        ButtonPanelOnOff.SetActive(false);
        SettingsOnOff.SetActive(true);
    }

    public void Settings_to_MainMenu()
    {
        ButtonPanelOnOff.SetActive(true);
        SettingsOnOff.SetActive(false);
        start.Select();
    }

    
}
