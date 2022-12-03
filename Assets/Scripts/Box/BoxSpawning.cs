using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawning : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform boxParent;
    public Transform dropArea;
    public float radius;
    
    private int[] array = { 1, 2, 3, 4, 5, 6, 10, 11 };
    private Transform currentBox;

    void Start()
    {
        StartCoroutine(InitiateSpawn());
    }

    IEnumerator InitiateSpawn()
    {
        for (int i = 0; i < array.Length; i++)
        {
            Instantiate(objectToSpawn, transform.position, objectToSpawn.transform.rotation, boxParent);
            selectBox(i);
            yield return StartCoroutine(SpawnBox(randomPoint(), 1f));
        }
    }

    IEnumerator SpawnBox(Vector2 finalPos, float time)
    {
        Vector2 startingPos = currentBox.position;
        
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            currentBox.position = Vector2.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private void selectBox(int index)
    {
        currentBox = boxParent.GetChild(index);
    }

    private Vector2 randomPoint()
    {
        Vector2 center = dropArea.position;
        Vector2 randomPoint = center + Random.insideUnitCircle * radius;
        return randomPoint;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(dropArea.position, radius);
    }
}
