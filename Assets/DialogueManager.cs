using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
  public TMP_Text nameText;
  public TMP_Text dialogueText;

  public Animator animator;


  private Queue<string> sentences;
  

    // Start is called before the first frame update
  void Start()
    {
      
        sentences = new Queue<string>();
        
    }
  
  
public void StartFirstDialogue(Dialogue dialogue) // Aller aller erster Dialog wird in die TextBox transferiert
  {
    
    animator.SetBool("Start", true);

    nameText.text = dialogue.name;

    sentences.Clear();

    foreach (string sentence in dialogue.sentences){
      sentences.Enqueue(sentence);
    }
    DisplayNextSentence();
  }


  public void StartDialogue(Dialogue dialogue) 
  {
    Debug.Log("Gleich");
    animator.SetBool("IsOpen", true);

    nameText.text = dialogue.name;

    sentences.Clear();

    foreach (string sentence in dialogue.sentences){
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
