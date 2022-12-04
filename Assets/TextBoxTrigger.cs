using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxTrigger : MonoBehaviour
{

    [SerializeField] bool keyDown;
    [SerializeField] bool textFieldUp = false;
    public Animator animator;
    public GameObject [] Texte;
    public DialogueTrigger dialogueTrigger;
    public int textIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetAxis ("Jump")!=0){
		    if(!keyDown){

            textFieldUp = true;
            FindObjectOfType<DialogueManager>().StartDialogue(textIndex);
        
		    keyDown = true;	
        
		    }
        }else {
            keyDown= false;
        }
}
public void textFieldDown(){
    textFieldUp = false;
}
    
}