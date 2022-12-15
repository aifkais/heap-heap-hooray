using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int[] levelArray;
    [SerializeField] private bool canSwap;

    [SerializeField] private int[] arry;
    public string txt = "";
    public char[] sortiertesArray;
    public string[] arrayAnzeige = new string[1000];
    public int[] sortierung = new int[1000];



    private void Start()
    {
        arry = new int[levelArray.Length];
    }

    public int[] getLevelArray()
    {
        return levelArray;
    }

    public void setArry(int[] arry)
    {
        this.arry = arry;
    }

    public int[] getArry()
    {
        return arry;
    }

    public bool getCanSwap()
    {
        return canSwap;
    }

    public void setCanSwap(bool canSwap)
    {
        this.canSwap = canSwap;
    }
}
