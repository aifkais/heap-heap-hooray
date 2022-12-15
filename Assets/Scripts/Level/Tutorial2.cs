using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Tutorial2 : MonoBehaviour
{
    [SerializeField] private LevelController levelController;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private BoxSpawning boxSpawner;
    [SerializeField] private Spawn spawn;
    [SerializeField] private TreeToArray treeToArray;
    [SerializeField] private Swap swap;
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private Compare compare;
    [SerializeField] private Beenden beenden;

    [SerializeField] private GameObject treeController;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject player;

    private bool canFinish = false;

    private void Start()
    {
        StartCoroutine(startGame());
    }

    private void Update()
    {
        float dist = Vector2.Distance(timer.transform.GetChild(0).gameObject.transform.position, player.transform.position);
        if (dist < 1)
        {
            timer.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            if (Input.GetKeyDown(KeyCode.E) && canFinish)
            {
                timer.transform.GetChild(0).gameObject.GetComponent<Beenden>().beenden();
            }
        }
        else
        {
            timer.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.4f);
        }
    }

    IEnumerator startGame()
    {
        dialogueManager.newSentence();

        spawn.spawnPlayer();
        yield return new WaitUntil(() => !spawn.getSpawning());

        dialogueManager.Open(7);
        yield return new WaitUntil(() => !dialogueManager.getInDialogue());

        boxSpawner.spawnBox();
        yield return new WaitForSeconds(8f);
        dialogueManager.Open(8);
        yield return new WaitUntil(() => !dialogueManager.getInDialogue());

        yield return new WaitForSeconds(10f);
        dialogueManager.Open(9);
        yield return new WaitUntil(() => !dialogueManager.getInDialogue());

        yield return new WaitUntil(() => treeToArray.AllPlaced());
        dialogueManager.Open(10);
        yield return new WaitUntil(() => !dialogueManager.getInDialogue());

        yield return new WaitForSeconds(1f);
        dialogueManager.Open(11);
        yield return new WaitUntil(() => !dialogueManager.getInDialogue());

        //yield return new WaitForSeconds(1f);
        //dialogueManager.Open(12); //Notfalls auf heapy klicken
        //yield return new WaitUntil(() => !dialogueManager.getInDialogue());

        yield return new WaitUntil(() => treeToArray.AllLocked());
        canFinish = true;
        dialogueManager.Open(13);
        yield return new WaitUntil(() => !dialogueManager.getInDialogue());

        timer.transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        dialogueManager.Open(14);
        yield return new WaitUntil(() => !dialogueManager.getInDialogue());

        

        yield return new WaitForSeconds(20f);
        dialogueManager.Open(15);
        yield return new WaitUntil(() => !dialogueManager.getInDialogue());
        yield return new WaitForSeconds(3f);
        dialogueManager.Open(16);
        yield return new WaitUntil(() => !dialogueManager.getInDialogue());
        beenden.beenden();
    }
}
