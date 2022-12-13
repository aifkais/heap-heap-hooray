using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject TimerText;
    private float timeSec = 0;
    private int timeMin = 0;
    private bool timerActive = false;

    public void SetTimer(bool timerActive)
    {
        this.timerActive = timerActive;
    }
    void Start()
    {
        TimerText.GetComponent<TextMeshPro>().text = "00:00.0";
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
