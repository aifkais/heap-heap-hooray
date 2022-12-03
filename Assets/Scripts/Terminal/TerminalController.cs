using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TerminalController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform terminal;
    [SerializeField] private GameObject terminalInterface;
    [SerializeField] private float radius;

    private bool isOpened;
    private bool isNearTerminal = false;
    private Vector3 playerPosition;

    void Start()
    {
        terminalInterface.SetActive(false);
    }

    void Update()
    {
        isNearTerminal = CheckTerminal();
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isOpened)
            {
                CloseTerminal();
            }
            else if (!isOpened && isNearTerminal)
            {
                OpenTerminal();
            }
        }
    }

    public void OpenTerminal()
    {
        playerPosition = player.position;
        terminalInterface.SetActive(true);
        isOpened = true;
    }

    public void CloseTerminal()
    {
        player.position = playerPosition;
        terminalInterface.SetActive(false);
        isOpened = false;
    }

    private bool CheckTerminal()
    {
        Vector3 direction = terminal.position;
        float dist = Vector3.Distance(player.position, terminal.position);
        if (dist < radius) return true;
            else return false;
    }

    private void OnDrawGizmos()
    {
        if (CheckTerminal()) Gizmos.color = Color.red;
            else Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(terminal.position, radius);
    }
}
