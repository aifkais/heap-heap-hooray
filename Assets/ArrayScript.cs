using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ArrayScript : MonoBehaviour
{

    private TextMeshProUGUI textMeshProUGUI;

    public GameObject [] myArrays = new GameObject[7];
    public  GameObject [] arrayAnzeige = new GameObject[7];
    private int[] mainArray = new int[7];
    public Sprite weiss;
    
    public int platzhalter;
    public int randomZahl;
    public Sprite[] spritos = new Sprite[10];

    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i <myArrays.Length; i++){
        randomZahl =  Random.Range(0, 10);  // Generiert eine zufällige Zahl zwischen 0-9
        myArrays[i].GetComponent<Attributes>().wert= randomZahl; 

        mainArray[i] = randomZahl; // Zufallszahl wird in IntArray zugefügt

        GameManager.instance.Text[i] = mainArray[i].ToString();

        }
        updatepic();
        
        
    }


    public void heapinArray(int züge){ // Die Letzte ArrayKugel wird in die Anzeige hinzugefügt
       
        int x = 7-züge;

        int y = züge-1;
        
        for(int i = 0; i <spritos.Length; i++){
            if(mainArray[0] == i){
                arrayAnzeige[y].GetComponent<Image>().sprite = spritos[i];
                
            }
        }


            platzhalter = mainArray[x];
            mainArray[x] = mainArray [0];
            mainArray [0] = platzhalter;
            
            
            updatepic();
            
       

    }


    public void changearraypos (int index ){ //Tauscht die ArrayPositionen
        

        if(index == 0){
            platzhalter = mainArray[6];
            mainArray[6] = mainArray [2];
            mainArray [2] = platzhalter;
            updatepic();
        }
        if(index == 1){
            platzhalter = mainArray[5];
            mainArray[5] = mainArray [2];
            mainArray [2] = platzhalter;
            updatepic();
        }
        if(index == 3){
            platzhalter = mainArray[4];
            mainArray[4] = mainArray [1];
            mainArray [1] = platzhalter;
            updatepic();
        }
        if(index == 4){
            platzhalter = mainArray[3];
            mainArray[3] = mainArray [1];
            mainArray [1] = platzhalter;
            updatepic();
        }
        if(index == 6){
            platzhalter = mainArray[2];
            mainArray[2] = mainArray [0];
            mainArray [0] = platzhalter;
            updatepic();
        }
        if(index == 7){
            platzhalter = mainArray[1];
            mainArray[1] = mainArray [0];
            mainArray [0] = platzhalter;
            updatepic();
        }
    }



    public void updatepic(){// Die Sprites der ArrayKugeln werden entsprechend der ArrayWerte aktuallisiert
        for(int i = 0; i <mainArray.Length; i++){
            for (int e = 0 ; e <spritos.Length; e++){
                if(mainArray[i]==e){ 
                myArrays[i].GetComponent<Image>().sprite = spritos[e];
        }
                GameManager.instance.Text[i] = mainArray[i].ToString();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
