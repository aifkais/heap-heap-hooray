using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalController : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject Terminal;
    public bool isOpened;

    void Start()
    {
        Terminal.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isOpened)
            {
                CloseTerminal();
            }
            else
            {
                OpenTerminal();
            }
        }
    }

    public void OpenTerminal()
    {
        Terminal.SetActive(true);
        Time.timeScale = 0f;
        isOpened = true;
    }

    public void CloseTerminal()
    {
        Terminal.SetActive(false);
        Time.timeScale = 1f;
        isOpened = false;
    }
}
