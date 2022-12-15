using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TreeToArray : MonoBehaviour
{
    [SerializeField] private GameObject gameController;
    [SerializeField] private GameObject arrayAnzeige;
    [SerializeField] private LevelController levelController;
    private int[] array;
    private int[] rightWrong;
    private bool setFirstArray;
    

    private void Start()
    {
        setFirstArray = true;
        array = new int[gameController.transform.GetComponent<LevelController>().getLevelArray().Length];
        rightWrong = new int[gameController.transform.GetComponent<LevelController>().getLevelArray().Length];
    }

    private void Update()
    {
        UpdateArray();
        arrayAnzeige.GetComponent<TextMeshPro>().text = formatArray();

        checkRightWrong();

        if (getFree() == 1)
        {
            transform.GetChild(0).GetComponent<Node>().setLocked(true);
        }

        if (AllPlaced() && setFirstArray == true)
        {
            setFirstArray = false;
            foreach (int item in array)
            {
                levelController.getArry()[Array.IndexOf(array, item)] = item;
            }
        }
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

    private int getFree()
    {
        int counter = transform.childCount;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Node>().getLocked())
            {
                counter--;
            }
        }
        return counter;
    }

    private void checkRightWrong()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Node>().getLocked())
            {
                rightWrong[i] = 1;
            }
            else if (!transform.GetChild(i).GetComponent<Node>().getLocked())
            {
                rightWrong[i] = 0; 
            }
        }
    }

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

    public bool AllLocked()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Node>().getLocked() == false)
                return false;
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

    public int[] getRightWrong()
    {
        return rightWrong;
    }

    private String formatArray()
    {
        String text = "";

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

    public bool isHeapified()
    {
        for (int i = array.Length -1 ; i > 0; i--)
        {
            if (transform.GetChild(i).GetComponent<Node>().getLocked() == false)
                if (array[i] > array[getParent(i)])
                    return false;
        }
        return true;
    }

    public void setArrayEmpty()
    {
        array = new int[gameController.transform.GetComponent<LevelController>().getLevelArray().Length];
    }

    //AUTO HEAP mit ANIMATION
    /*IEnumerator sort()
    {
        int[] array = treeToArray.getArray();
        while (!treeToArray.isHeapified())
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                if (treeController.transform.GetChild(i).GetComponent<Node>().getLocked() == false)
                    if (array[i] > array[treeToArray.getParent(i)])
                    {
                        swap.select(treeController.transform.GetChild(i).gameObject);
                        yield return new WaitForSeconds(0.5f);
                        swap.select(treeController.transform.GetChild(treeToArray.getParent(i)).gameObject);
                        //yield return new WaitUntil(() => swap.getInAnimation());
                        yield return new WaitForSeconds(2f);
                    }
            }
        }
    }*/
}
