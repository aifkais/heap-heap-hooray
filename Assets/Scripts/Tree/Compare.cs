using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compare : MonoBehaviour
{
    private TreeToArray treeToArray;
    [SerializeField] private LevelController levelController;

    private void Start()
    {
        treeToArray = transform.GetComponent<TreeToArray>();
    }

    public bool compareArrays(int sortierschritt)
    {
        if (sortierschritt == -1)
        {
            return false;
        }
        if (treeToArray.AllPlaced())
        {
            if (String.Equals(levelController.arrayAnzeige[sortierschritt], toString(treeToArray.getArray())))
                return true;
            else return false;
        }
        else return false;
    }

    /*public bool checkLast()
    {
        int lastIndex = 0;
        for (int i = 0; i < levelController.arrayAnzeige.Length; i++)
        {
            if (levelController.arrayAnzeige[i] == null)
                lastIndex = i - 1;
        }
        if (compareArrays(lastIndex))
            return true;
        else return false;
    }*/

    private string toString(int[] array)
    {
        string text = "";
        foreach (var item in array)
        {
            text += "" + item;
        }
        return text;
    }
}
