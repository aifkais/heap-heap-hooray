using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject spawnPoint;
    private bool spawning = false;

    public void spawnPlayer()
    {
        StartCoroutine(InitiateSpawn());
    }

    public IEnumerator InitiateSpawn()
    {
        spawning = true;
        yield return StartCoroutine(OpenDoor());
        yield return StartCoroutine(SpawnPlayer());
        transform.GetComponent<Animator>().SetFloat("Vertical", 0);
        yield return StartCoroutine(CloseDoor());
        door.GetComponent<SpriteRenderer>().sortingOrder = 0;
        door.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
        transform.GetComponent<PlayerMovement>().setCanMove(true);
        spawning = false;
    }

    IEnumerator SpawnPlayer()
    {
        Vector2 startingPos = transform.position;
        float speed = 5f;
        float dist = Vector2.Distance(startingPos, spawnPoint.transform.position);

        float elapsedTime = 0;
        
        while (elapsedTime < (dist / speed))
        {
            transform.GetComponent<Animator>().SetFloat("Vertical", -1);
            transform.position = Vector2.Lerp(startingPos, spawnPoint.transform.position, (elapsedTime / (dist / speed)));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
    }

    IEnumerator OpenDoor()
    {
        door.GetComponent<Animator>().SetTrigger("Open");
        yield return new WaitForSeconds(1);
    }

    IEnumerator CloseDoor()
    {
        door.GetComponent<Animator>().SetTrigger("Close");
        yield return new WaitForSeconds(1);
    }

    public bool getSpawning()
    {
        return spawning;
    }
}
