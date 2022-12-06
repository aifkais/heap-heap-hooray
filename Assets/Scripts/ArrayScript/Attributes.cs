using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attributes : MonoBehaviour
{
    public int wert=1;
    public int xwert = 1;
    public int ywert = 1;
    public int index  = 1;
    public Attributes next = null;
    public bool isActive = true;


    public Attributes (int wert, int xwert, int ywert, int index, bool isActive , Attributes next){
        this.wert = wert;
        this.xwert = xwert;
        this.ywert = ywert;
        this.index = index;
        this.isActive = isActive;

        this.next =next;
    }

    
    


}
