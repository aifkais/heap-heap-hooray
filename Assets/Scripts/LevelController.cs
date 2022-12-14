using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int[] levelArray;
    [SerializeField] private int levelDialogueIndex;

    [SerializeField] private int[] arry;
    public string txt = "";
    public char[] sortiertesArray;
    public string[] arrayAnzeige = new string[1000];

    private void Start()
    {
        arry = new int[levelArray.Length];
    }

    public int[] getLevelArray()
    {
        return levelArray;
    }

    public int getLevelDialogueIndex()
    {
        return levelDialogueIndex;
    }

    public void setArry(int[] arry)
    {
        this.arry = arry;
    }

    public int[] getArry()
    {
        return arry;
    }
}
