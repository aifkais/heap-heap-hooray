using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxTrigger : MonoBehaviour
{

    [SerializeField] bool keyDown;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis ("Jump")!=0){
		if(!keyDown){

            
		animator.SetBool("IsOpen", true);
		keyDown = true;	
        
		}else {
            keyDown= false;
        }
    }
}
}