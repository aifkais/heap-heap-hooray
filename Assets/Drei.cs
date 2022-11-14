using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drei : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(menuButtonController.index == 0&&Input.GetAxis ("Jump")>0){
            transform.position = new Vector3(3400, 130);
            
        }
    }
}
