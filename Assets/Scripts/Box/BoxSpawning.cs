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

    [SerializeField] private GameObject gameController;

    private float speed = 5f;
    private int[] unsortetdList;
    private GameObject currentBox;

    void Start()
    {
        unsortetdList = gameController.GetComponent<LevelController>().getLevelArray();
        StartCoroutine(InitiateSpawn());
    }

    IEnumerator InitiateSpawn()
    {
        for (int i = 0; i < unsortetdList.Length; i++)
        {
            Instantiate(objectToSpawn, transform.position, objectToSpawn.transform.rotation, boxParent);
            selectBox(i);
            currentBox.transform.GetComponent<Box>().setBoxValue(unsortetdList[i]);
            yield return StartCoroutine(SpawnBox(randomPoint()));
        }
        enablePickUp();
    }

    IEnumerator SpawnBox(Vector2 finalPos)
    {
        Vector2 startingPos = currentBox.transform.position;
        float dist = Vector2.Distance(startingPos, finalPos);
        
        float elapsedTime = 0;

        while (elapsedTime < (dist / speed))
        {
            currentBox.transform.position = Vector2.Lerp(startingPos, finalPos, (elapsedTime / (dist / speed)));
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

    private void enablePickUp()
    {
        for (int i = 0; i < unsortetdList.Length; i++)
        {
            boxParent.GetChild(i).gameObject.GetComponent<Box>().setPickUpAllowed(true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(dropArea.position, radius);
    }
}
