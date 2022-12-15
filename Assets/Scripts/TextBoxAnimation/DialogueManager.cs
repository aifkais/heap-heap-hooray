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
    [SerializeField] bool keyDown;
    [SerializeField] private LevelController levelController;

    public Dialogue [] textArray = new Dialogue [50];
    private Queue<string> sentences;

    private bool inDialogue = false;
  
  
   void Update() // loest die TextBoxen aus
    {
        if (Input.GetKey("space"))
        {
            if (!keyDown && animator.GetBool("IsOpen") == true)
            {
                DisplayNextSentence();
                keyDown = true;
            }
        }
        else
        {
            keyDown = false;
        }
    }

    public void Open(int textIndex)
    {
        if (!keyDown && animator.GetBool("IsOpen") == false)
        {
            StartDialogue(textIndex);
            keyDown = true;
        }
    }

    public void newSentence()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(int textIndex)
    {
        inDialogue = true;
        animator.SetBool("IsOpen", true);

        nameText.text = textArray[textIndex].npcName;

        sentences.Clear();

        foreach (string sentence in textArray[textIndex].sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }



    public void DisplayNextSentence(){

    if(sentences.Count == 0){
            inDialogue = false;
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

    public bool getInDialogue()
    {
        return inDialogue;
    }
}
