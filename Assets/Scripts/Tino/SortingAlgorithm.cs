using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class SortingAlgorithm : MonoBehaviour
{
    [SerializeField] private LevelController levelController;
    private TextMeshProUGUI textMeshProUGUI;
    private int laengeArray;
    
    
    //Heapsort
    public int[] SortArray(int[] array, int size)
    {
        if (size <= 1)
            return array;
        for (int i = size / 2 - 1; i >= 0; i--)
        {
                Heapify(array, size, i);
        }
        for (int i = size - 1; i >= 0; i--)
        {
            var tempVar = array[0];
            array[0] = array[i];
            array[i] = tempVar;
            
                Heapify(array, i, 0);
        }

        // String zu Char Array
        levelController.sortiertesArray = new char[levelController.txt.Length];
        for(int i = 0; i <= levelController.txt.Length; i++)
        {
            levelController.sortiertesArray = levelController.txt.ToCharArray();
        }
        // Char Array zerteilen
        
        for (int i = 0; i < levelController.sortiertesArray.Length/ laengeArray; i++)
        {
           for(int j = 0; j < 7; j++)
            {
                levelController.arrayAnzeige[i] = levelController.arrayAnzeige[i] + levelController.sortiertesArray[j + i * 7];
            }
        }

        GleicheEliminieren(levelController.arrayAnzeige);
        GleicheEliminieren(levelController.arrayAnzeige);

        return array;
    }

    void Heapify(int[] array, int size, int index)
    {
        var largestIndex = index;
        var leftChild = 2 * index + 1;
        var rightChild = 2 * index + 2;
        if (leftChild < size && array[leftChild] > array[largestIndex])
        {
            largestIndex = leftChild;
        }
        if (rightChild < size && array[rightChild] > array[largestIndex])
        {
            largestIndex = rightChild;
        }
        if (largestIndex != index)
        {
            var tempVar = array[index];
            array[index] = array[largestIndex];
            array[largestIndex] = tempVar;
            Heapify(array, size, largestIndex);
        }
        ArrayText(array);
    }
    
    void ArrayText(int[] array1)
    {
        for(int i = 0; i<array1.Length; i++)
        {
            levelController.txt += array1[i];
        }
    }

    void GleicheEliminieren(string[] strings)
    {
        for (int i = 0; i < strings.Length - 1; i++)
        {
            if (string.Equals(strings[i], strings[i + 1]))
            {
                for (int j = i; j < strings.Length - 1; j++)
                {
                    strings[j] = strings[j + 1];
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI = gameObject.GetComponent<TextMeshProUGUI>();
        laengeArray = levelController.getLevelArray().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SortArray(levelController.arry, levelController.arry.Length);
        }        
    }
}
