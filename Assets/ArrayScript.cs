using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArrayScript : MonoBehaviour
{

    public GameObject [] myArrays = new GameObject[7];
    private int[] mainArray = new int[7];
    public int platzhalter;
    public int randomZahl;
    public Sprite eins;
    public Sprite zwei;
    public Sprite drei;
    public Sprite vier;
    public Sprite fünf;
    public Sprite sechs;
    public Sprite sieben;
    public Sprite acht;
    public Sprite neun;
    public Sprite nurr;
    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i <myArrays.Length; i++){
        randomZahl =  Random.Range(0, 10);  // Generiert eine zufällige Zahl zwischen 0-9
        myArrays[i].GetComponent<Attributes>().wert= randomZahl; 

        mainArray[i] = randomZahl; // Zufallszahl wird in IntArray zugefügt
        }
        updatepic();
        
        
    }

    public void metomethod1 (int index ){
        

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

    public void updatepic(){
        for(int i = 0; i <mainArray.Length; i++){
        if(mainArray[i]==0){ // Bilder werden aktuallisiert
            myArrays[i].GetComponent<Image>().sprite = nurr;
        }
        if(mainArray[i]==1){
            myArrays[i].GetComponent<Image>().sprite = eins;
        }
        if(mainArray[i]==2){
            myArrays[i].GetComponent<Image>().sprite = zwei;
        }
        if(mainArray[i]==3){
            myArrays[i].GetComponent<Image>().sprite = drei;
        }
        if(mainArray[i]==4){
            myArrays[i].GetComponent<Image>().sprite = vier;
        }
        if(mainArray[i]==5){
            myArrays[i].GetComponent<Image>().sprite = fünf;
        }
        if(mainArray[i]==6){
            myArrays[i].GetComponent<Image>().sprite = sechs;
        }
        if(mainArray[i]==7){
            myArrays[i].GetComponent<Image>().sprite = sieben;
        }
        if(mainArray[i]==8){
            myArrays[i].GetComponent<Image>().sprite = acht;
        }
        if(mainArray[i]==9){
            myArrays[i].GetComponent<Image>().sprite = neun;
        }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
