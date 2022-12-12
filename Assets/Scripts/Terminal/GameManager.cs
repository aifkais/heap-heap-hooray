using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string[] Text = new string[7];
    public int[] arry = new int[7];
    public string txt = "";
    public char[] sortiertesArray;
    public string[] arrayAnzeige = new string[1000];
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
