using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SelectTutorial()
    {
        string buttonString = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        char lastCharacter = buttonString[buttonString.Length - 1];
        int levelIndex = lastCharacter - '0';
        SceneManager.LoadScene(2 + levelIndex);
    }

    public void SelectLevel()
    {
        string buttonString = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        char lastCharacter = buttonString[buttonString.Length - 1];
        int levelIndex = lastCharacter - '0';
        SceneManager.LoadScene(4 + levelIndex);
    }
}
