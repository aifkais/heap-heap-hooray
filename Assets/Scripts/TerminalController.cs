using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalController : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject Terminal;
    public bool isOpened;

    private Vector3 playerPosition;

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
            else if (!isOpened && player.GetComponent<PlayerMovement>().getIsNearTerminal())
            {
                OpenTerminal();
            }
        }
    }

    public void OpenTerminal()
    {
        playerPosition = player.transform.position;
        Terminal.SetActive(true);
        isOpened = true;
    }

    public void CloseTerminal()
    {
        player.transform.position = playerPosition;
        Terminal.SetActive(false);
        isOpened = false;
    }
}
