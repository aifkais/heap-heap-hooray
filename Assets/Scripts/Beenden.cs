using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Beenden : MonoBehaviour
{
    [SerializeField] private LevelController levelController;
    [SerializeField] private TreeToArray treeToArray;
    [SerializeField] private TextMeshPro timeText;
    [SerializeField] private GameObject endScreen;
    private int[] ausgangsarray;
    private int[] abschlussarray;
    private string time;
    private int[] rightWrong;
    private int right = 0;
    private int wrong = 0;

    [SerializeField] private TextMeshProUGUI esausgansarray;
    [SerializeField] private TextMeshProUGUI esabschlussarray;
    [SerializeField] private TextMeshProUGUI eszeit;
    [SerializeField] private TextMeshProUGUI esrichtig;
    [SerializeField] private TextMeshProUGUI esfalsch;

    public void beenden()
    {
        ausgangsarray = levelController.getLevelArray();
        abschlussarray = treeToArray.getArray();
        time = timeText.text;
        rightWrong = treeToArray.getRightWrong();

        string ausgangsArrayText = formatArray(ausgangsarray);
        string abschlussArrayText = formatArray(abschlussarray);
        countRightWrong();

        endScreen.SetActive(true);

        esausgansarray.text = ausgangsArrayText;
        esabschlussarray.text = abschlussArrayText;

        eszeit.text = time;
        esrichtig.text = "" + right;
        esfalsch.text = "" + wrong;
    }

    private string formatArray(int[] array)
    {
        string text = "";

        foreach (var item in array)
        {
            if (item == 0)
                text += "- ";
            else
                text += item + " ";
        }
        text = text.Remove(text.Length - 1);
        return text;
    }

    private void countRightWrong()
    {
        right = 0;
        wrong = 0;
        foreach (var item in rightWrong)
        {
            if (item == 0)
                wrong++;
            else if (item == 1)
                right++;
        }
    }
}
