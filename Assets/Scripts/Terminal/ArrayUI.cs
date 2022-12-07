using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ArrayUI : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;
    private int zaehler = 0;
    private int laengeArray = 7;
    
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
        GameManager.instance.sortiertesArray = new char[GameManager.instance.txt.Length];
        for(int i = 0; i <= GameManager.instance.txt.Length; i++)
        {
            GameManager.instance.sortiertesArray = GameManager.instance.txt.ToCharArray();
        }
        // Char Array zerteilen
        
        for (int i = 0; i < GameManager.instance.sortiertesArray.Length/ laengeArray; i++)
        {
           for(int j = 0; j < 7; j++)
            {
                GameManager.instance.arrayAnzeige[i] = GameManager.instance.arrayAnzeige[i] + GameManager.instance.sortiertesArray[j + i * 7];
            }
        }

        GleicheEliminieren(GameManager.instance.arrayAnzeige);

        return array;
    }

    static void Heapify(int[] array, int size, int index)
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
    
    public static void ArrayText(int[] array1)
    {
        for(int i = 0; i<array1.Length; i++)
        {
                GameManager.instance.txt += array1[i];
        }
        
    }

    public static void GleicheEliminieren(string[] strings)
    {
        for(int i=0; i<strings.Length; i++)
        {
            if(i != strings.Length - 1)
            {
                if (string.Equals(strings[i], strings[i + 1]))
                {
                    strings[i + 1]= "";
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI = gameObject.GetComponent<TextMeshProUGUI>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            zaehler += 1;
            if (GameManager.instance.arrayAnzeige[zaehler] == "")            
               zaehler += 1;
                
            
            textMeshProUGUI.text = GameManager.instance.arrayAnzeige[zaehler];


            //textMeshProUGUI.text = GameManager.instance.ablage.Length.ToString();/"Array: [" + GameManager.instance.arry[0].ToString() + "," + GameManager.instance.arry[1].ToString() + "," + GameManager.instance.arry[2].ToString() + "," + GameManager.instance.arry[3].ToString() + "," + GameManager.instance.arry[4].ToString() + "," + GameManager.instance.arry[5].ToString() + "," + GameManager.instance.arry[6].ToString() + "]";
        }
        if (Input.GetKeyDown(KeyCode.O))        
            SortArray(GameManager.instance.arry, GameManager.instance.arry.Length);
        
    }
}
