using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public void SetFullscreen(bool isFullscreen)
    {
           Screen.fullScreen = isFullscreen;
    }

    public void fullScreen()
    { Debug.Log( "fullscreen");

    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
     public void BackToMenu()
    {
         SceneManager.LoadScene("Menu");
    }

}
