using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
  public TMP_Text nameText;
  public TMP_Text dialogueText;
  public TextBoxTrigger textBoxTrigger;

  public Animator animator;
  public Dialogue [] textArray = new Dialogue [50];

  private Queue<string> sentences;
  

    // Start is called before the first frame update
  void Start()
    {
      
        sentences = new Queue<string>();
        
    }
  
  



  public void StartDialogue(int textIndex) 
  {
    Debug.Log("Gleich");
    animator.SetBool("IsOpen", true);

    nameText.text = textArray[textIndex].name;

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
