using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int[] levelArray;

    public int[] getLevelArray()
    {
        return levelArray;
    }
}
