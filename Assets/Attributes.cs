using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attributes : MonoBehaviour
{
    public int wert=1;
    public Sprite eins;
    public Sprite zwei;
    public Sprite drei;
    public SpriteRenderer sr;


    public void changepic(){
        if(this.wert == 1){
            GetComponent<Image>().sprite = eins;
        }
        if(this.wert == 2){
            GetComponent<Image>().sprite = zwei;
        }
        if(this.wert == 3){
            GetComponent<Image>().sprite = drei;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //changepic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
