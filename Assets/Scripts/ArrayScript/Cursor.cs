using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{

    [SerializeField] MenuButtonController menuButtonController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(menuButtonController.index == 0){
            transform.position = new Vector3(3400, 130);
            
        }else if(menuButtonController.index==1){
            transform.position = new Vector3(2300, 130);
        }else if(menuButtonController.index==2){
            transform.position = new Vector3(1910, 130);
        }else if(menuButtonController.index==3){
            transform.position = new Vector3(1550, 130);
        }else if(menuButtonController.index==4){
            transform.position = new Vector3(450, 130);
        }else if(menuButtonController.index==5){
            transform.position = new Vector3(100, 130);
            
        }else if(menuButtonController.index==6){
            transform.position = new Vector3(2850, 850);
        }else if(menuButtonController.index==7){
            transform.position = new Vector3(1000, 850);
        }else if(menuButtonController.index==8){
            transform.position = new Vector3(650, 850);
        }
        
    }
}
