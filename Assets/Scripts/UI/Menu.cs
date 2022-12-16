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

    public Sprite newbuttonimage;
    public Button button;
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void Changebuttonimage()
    {
        button.image.sprite = newbuttonimage;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("scene_main_julia");
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
    }
}
