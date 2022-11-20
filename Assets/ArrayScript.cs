using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArrayScript : MonoBehaviour
{

    public GameObject [] myArrays = new GameObject[8];

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

        myArrays[i].GetComponent<Attributes>().wert= Random.Range(1, 10);
        Debug.Log(myArrays[i].GetComponent<Attributes>().wert); 
        if(myArrays[i].GetComponent<Attributes>().wert==0){
            myArrays[i].GetComponent<Image>().sprite = nurr;
        }
        if(myArrays[i].GetComponent<Attributes>().wert==1){
            myArrays[i].GetComponent<Image>().sprite = eins;
        }
        if(myArrays[i].GetComponent<Attributes>().wert==2){
            myArrays[i].GetComponent<Image>().sprite = zwei;
        }
        if(myArrays[i].GetComponent<Attributes>().wert==3){
            myArrays[i].GetComponent<Image>().sprite = drei;
        }
        if(myArrays[i].GetComponent<Attributes>().wert==4){
            myArrays[i].GetComponent<Image>().sprite = vier;
        }
        if(myArrays[i].GetComponent<Attributes>().wert==5){
            myArrays[i].GetComponent<Image>().sprite = fünf;
        }
        if(myArrays[i].GetComponent<Attributes>().wert==6){
            myArrays[i].GetComponent<Image>().sprite = sechs;
        }
        if(myArrays[i].GetComponent<Attributes>().wert==7){
            myArrays[i].GetComponent<Image>().sprite = sieben;
        }
        if(myArrays[i].GetComponent<Attributes>().wert==8){
            myArrays[i].GetComponent<Image>().sprite = acht;
        }
        if(myArrays[i].GetComponent<Attributes>().wert==9){
            myArrays[i].GetComponent<Image>().sprite = neun;
        }
        
        
        }


    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
