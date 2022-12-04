using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
public GameObject [] textArray = new GameObject[50];

    public void TriggerDialogue(int textIndex){
        
        FindObjectOfType<DialogueManager>().StartDialogue(textIndex);
    }







}
