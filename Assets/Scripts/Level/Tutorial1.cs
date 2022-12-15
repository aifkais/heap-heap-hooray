using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Tutorial1 : MonoBehaviour
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

    private void Start()
    {
        StartCoroutine(startGame());
    }

    IEnumerator startGame()
    {
        dialogueManager.newSentence();

        dialogueManager.Open(0);
        yield return new WaitUntil(() => !dialogueManager.getInDialogue());

        spawn.spawnPlayer();
        yield return new WaitUntil(() => !spawn.getSpawning());

        dialogueManager.Open(1);
        yield return new WaitUntil(() => !dialogueManager.getInDialogue());
        
        boxSpawner.spawnBox();
        yield return new WaitUntil(() => treeToArray.AllPlaced());
        yield return StartCoroutine(sort());

        dialogueManager.Open(2);
        yield return new WaitForSeconds(2f);
        yield return new WaitUntil(() => !dialogueManager.getInDialogue());

        boxSpawner.spawnBox();
        yield return new WaitForSeconds(1f);
        dialogueManager.Open(3);
        yield return new WaitUntil(() => !dialogueManager.getInDialogue());

        yield return new WaitUntil(() => treeToArray.AllPlaced());
        dialogueManager.Open(4);
        yield return new WaitUntil(() => !dialogueManager.getInDialogue());
        levelController.setCanSwap(true);

        yield return new WaitUntil(() => treeToArray.AllLocked());

        yield return new WaitForSeconds(1f);
        dialogueManager.Open(5);
        yield return new WaitUntil(() => !dialogueManager.getInDialogue());
        beenden.beenden();
    }

    IEnumerator sort()
    {
        int[] array = treeToArray.getArray();
        for (int i = array.Length - 1; i > 0; i--)
        {
            if (treeController.transform.GetChild(i).GetComponent<Node>().getLocked() == false)
                if (array[i] > array[treeToArray.getParent(i)])
                {
                    swap.select(treeController.transform.GetChild(i).gameObject);
                    yield return new WaitForSeconds(0.5f);
                    swap.select(treeController.transform.GetChild(treeToArray.getParent(i)).gameObject);
                    yield return new WaitForSeconds(2f);
                }
        }

        //error sequenz
        cameraShake.startShake();
        explosion.Play();
        treeToArray.setArrayEmpty();
        for (int i = 0; i < array.Length; i++)
        {
            Destroy(treeController.transform.GetChild(i).GetComponent<Node>().getPlacedBox());
        }
        yield return new WaitForSeconds(1f);
    }
}
