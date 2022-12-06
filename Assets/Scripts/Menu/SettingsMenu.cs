//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

// public class SettingsMenu : MonoBehaviour
// {
// // <<<<<<< HEAD
// //     public void SetFullscreen(bool isFullscreen);
// //     public void SetQuality(int qualityIndex);
// =======

//     public Toggle fullscreenToggle;


//     private void Start()
//     {
//         if (Screen.fullScreen == true)
//         {
//             fullscreenToggle.isOn = true;
//         }
//         else
//         {
//             fullscreenToggle.isOn = false;
//         }
//     }


//     public void BackToMenu()
// >>>>>>> ad4bdea645c46cf84fac6b1f8f631d25ee016483
//     {
//            Screen.fullScreen = isFullscreen;
           
//     }

//     public void fullScreen()
//     { Debug.Log( "fullscreen");

//     }
//     public void SetQuality(int qualityIndex)
//     {
//         QualitySettings.SetQualityLevel(qualityIndex);
//     }
//      public void BackToMenu()
//     {
//          SceneManager.LoadScene("Menu");
//     }

// }


public class SettingsMenu : MonoBehaviour
{
     public void BackToMenu()
    {
         SceneManager.LoadScene("Menu");
    }

    public void SetFullscreen(bool isFullscreen){
        Screen.fullScreen= isFullscreen;
    }



    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}