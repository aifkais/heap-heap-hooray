using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Box: MonoBehaviour
{
    private int boxValue;
    private bool showBoxValue = false;
    private bool pickUpAllowed = false;

    private void Update()
    {
        this.transform.GetChild(0).Find("BoxValueText").gameObject.GetComponent<TextMeshPro>().text = "" + boxValue;

        if (showBoxValue)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (!showBoxValue)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public int getBoxValue()
    {
        return boxValue;
    }

    public void setBoxValue(int boxValue)
    {
        this.boxValue = boxValue;
    }

    public bool getShowBoxValue()
    {
        return showBoxValue;
    }

    public void setShowBoxValue(bool showBoxValue)
    {
        this.showBoxValue = showBoxValue;
    }

    public bool getPickUpAllowed()
    {
        return pickUpAllowed;
    }

    public void setPickUpAllowed(bool pickUpAllowed)
    {
        this.pickUpAllowed = pickUpAllowed;
    }
}
