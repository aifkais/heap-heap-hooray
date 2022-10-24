using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;


    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void TriggerFirst(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

   [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
       
         Debug.Log("After Scene is loaded and game is running");
    }


}
