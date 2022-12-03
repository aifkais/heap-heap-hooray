using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxSpawning : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Transform boxParent;
    [SerializeField] private Transform dropArea;
    [SerializeField] private float radius;
    
    private int[] unsortetdList = { 1, 2, 3, 4, 5, 6, 10, 11 };
    private GameObject currentBox;

    void Start()
    {
        StartCoroutine(InitiateSpawn());
    }

    IEnumerator InitiateSpawn()
    {
        for (int i = 0; i < unsortetdList.Length; i++)
        {
            Instantiate(objectToSpawn, transform.position, objectToSpawn.transform.rotation, boxParent);
            selectBox(i);
            currentBox.transform.GetComponent<Box>().setBoxValue(unsortetdList[i]);
            currentBox.transform.GetChild(0).Find("BoxValueText").gameObject.GetComponent<TextMeshPro>().text = "" + unsortetdList[i];
            yield return StartCoroutine(SpawnBox(randomPoint(), 1f));
        }
    }

    IEnumerator SpawnBox(Vector2 finalPos, float time)
    {
        Vector2 startingPos = currentBox.transform.position;
        
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            currentBox.transform.position = Vector2.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private void selectBox(int index)
    {
        currentBox = boxParent.GetChild(index).gameObject;
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
