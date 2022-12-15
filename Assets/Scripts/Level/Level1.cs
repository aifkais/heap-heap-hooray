using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Level1 : MonoBehaviour
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

    IEnumerator startGame()
    {
        dialogueManager.newSentence();

        spawn.spawnPlayer();
        yield return new WaitUntil(() => !spawn.getSpawning());
        boxSpawner.spawnBox();
    }
}
