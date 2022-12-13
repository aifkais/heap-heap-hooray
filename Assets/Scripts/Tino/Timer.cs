using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject TimerText;
    private float timeSec = 50;
    private int timeMin = 59;
    private bool timerActive = true;
    void Start()
    {
        TimerText.GetComponent<TextMeshPro>().text = "00:00";
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            timeSec += 1 * Time.deltaTime;
            if (timeSec >= 60)
            {
                timeMin++;
                timeSec = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            timerActive = false;
        }
        TimerText.GetComponent<TextMeshPro>().text = timeMin.ToString(@"00\:")+ timeSec.ToString(@"00.0");

        if(timeMin == 60)
        {
            TimerText.GetComponent<TextMeshPro>().text = "Looser";
            timerActive = false;
        }
       
    }
}
