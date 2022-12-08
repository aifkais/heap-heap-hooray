using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
  public TMP_Text nameText;
  public TMP_Text dialogueText;
  //public TextBoxTrigger textBoxTrigger;
  public GameObject btn;
  public Animator animator;
  public Dialogue [] textArray = new Dialogue [50];

  private Queue<string> sentences;
  

  [SerializeField] bool keyDown;
    
 
  //public GameObject [] Texte;
  //public DialogueTrigger dialogueTrigger;
  public int textIndex =0;



    // Start is called before the first frame update
  void Start()
    {
      
        sentences = new Queue<string>();
        
    }
  
  
   void Update()
    {
        
        if(Input.GetAxis ("Jump")!=0){
		    if(!keyDown&&animator.GetBool("IsOpen")==false){

        StartDialogue(textIndex);
		    keyDown = true;	  
		    } else if(!keyDown&&animator.GetBool("IsOpen")==true){
          
         DisplayNextSentence();
         keyDown = true;	 
        }
        }

        
        else {
        keyDown= false;
        }
}


  public void StartDialogue(int textIndex) 
  {
    
    animator.SetBool("IsOpen", true);

    nameText.text = textArray[textIndex].npcName;

    sentences.Clear();

    foreach (string sentence in textArray[textIndex].sentences){
      sentences.Enqueue(sentence);
    }
    DisplayNextSentence();
  }
 


  public void DisplayNextSentence(){

    if(sentences.Count == 0){
    
      EndDialogue();
      return;
    }

    string sentence = sentences.Dequeue();
    StopAllCoroutines();
    StartCoroutine(TypeSentence(sentence));
  }

  IEnumerator TypeSentence (string sentence){
    dialogueText.text ="";
    foreach(char letter in sentence.ToCharArray()){
      dialogueText.text+=letter;
      yield return null;
    }
  }

  void EndDialogue(){
    animator.SetBool("IsOpen", false);
   
    
  }
}
