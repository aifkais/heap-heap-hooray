using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int[] levelArray;
    [SerializeField] private int levelDialogueIndex;

    public int[] getLevelArray()
    {
        return levelArray;
    }

    public int getLevelDialogueIndex()
    {
        return levelDialogueIndex;
    }
}
