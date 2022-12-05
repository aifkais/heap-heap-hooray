using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Toggle fullscreenToggle;


    private void Start()
    {
        if (Screen.fullScreen == true)
        {
            fullscreenToggle.isOn = true;
        }
        else
        {
            fullscreenToggle.isOn = false;
        }
    }


    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
