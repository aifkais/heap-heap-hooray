using System;
using TMPro;
using UnityEngine;

public class TreeToArray : MonoBehaviour
{
    [SerializeField] private GameObject gameController;
    [SerializeField] private GameObject arrayAnzeige;
    private int[] array;

    //GameManager.instance.arry = array;

    private void Start()
    {
        array = new int[gameController.transform.GetComponent<LevelController>().getLevelArray().Length];
    }

    private void Update()
    {
        UpdateArray();
        arrayAnzeige.GetComponent<TextMeshPro>().text = formatArray();

        print(getLastIndex());
        
    }

    private void UpdateArray()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject box = transform.GetChild(i).GetComponent<Node>().getPlacedBox();
            if (box)
            {
                array[i] = box.GetComponent<Box>().getBoxValue();
            }
        }
    }

    /*private void lockLastNode()
    {
        if (getLargestValue() == getLast())
        {
            transform.GetChild(Array.IndexOf(array, getLast())).GetComponent<Node>().setLocked(true);
        }
    }*/

    public int getLargestValue() //That is not locked
    {
        int max = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (transform.GetChild(i).GetComponent<Node>().getLocked() == false) //nur wenn node nicht locked ist
                if (array[i] > max) max = array[i];
        }
        return max;
    }

    public int getLastIndex() //That is not locked
    {
        int last = 0;
        for (int i = 0; i < array.Length; i++)
        {
            last = i;
            if (transform.GetChild(i).GetComponent<Node>().getLocked() == true)
            {
                last--;
                break;
            }
        }
        return last;
    }

    public bool AllPlaced()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject box = transform.GetChild(i).GetComponent<Node>().getPlacedBox();
            if (!box)
            {
                return false;
            }
        }
        return true;
    }

    public int getParent(float index)
    {
        return (int)Math.Floor((index - 1) / 2);
    }

    

    public int[] getArray()
    {
        return array;
    }

    private String formatArray()
    {
        String text = "";

        foreach (var item in array)
        {
            text += item + " ";
        }
        text = text.Remove(text.Length - 1);
        return text;
    }
}
