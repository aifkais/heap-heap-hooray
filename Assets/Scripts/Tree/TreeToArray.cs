using System;
using TMPro;
using UnityEngine;

public class TreeToArray : MonoBehaviour
{
    [SerializeField] private GameObject gameController;
    [SerializeField] private GameObject arrayAnzeige;
    private int[] array;

    //GameManager.instance.arry[i] = mainArray[i];

    private void Start()
    {
        array = new int[gameController.transform.GetComponent<LevelController>().getLevelArray().Length];
    }

    private void Update()
    {
        UpdateArray();
        arrayAnzeige.GetComponent<TextMeshPro>().text = formatArray();
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
