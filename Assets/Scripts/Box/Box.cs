using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box: MonoBehaviour
{
    private int boxValue;

    public int getBoxValue()
    {
        return boxValue;
    }

    public void setBoxValue(int boxValue)
    {
        this.boxValue = boxValue;
    }
}
