using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    [SerializeField] private GameObject escapescreen;
    [SerializeField] private Timer timer;
    [SerializeField] private Transform box;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //Mit Escape Escapescreen öffnen und schließen
        {
            if (escapescreen.activeSelf)
            {
                escapescreen.SetActive(false);
            }
            else
            {
                timer.SetTimer(false);
                escapescreen.SetActive(true);
            }
        }
        try     // Index Array out of Bounds, weil Packete noch nicht gespawned sind
        {
            if (!escapescreen.activeSelf && box.GetChild(0).gameObject.GetComponent<Box>().getPickUpAllowed())  //Timer aktivieren beim schließen des Fensters
            {
                timer.SetTimer(true);
            }
        }
        catch (Exception) { }
       
    }
}
