using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Node : MonoBehaviour
{
    private float radius = 0.75f;
    private GameObject placedBox;
    private bool locked = false;

    private void Update()
    {
        if (placedBox)
        {
            placedBox.transform.position = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Box" && !placedBox)
        {
            placedBox = collision.gameObject;
            placedBox.GetComponent<Collider2D>().enabled = false;
            placedBox.transform.position = transform.position;
            placedBox.GetComponent<Box>().setShowBoxValue(true);
            placedBox.GetComponent<Box>().setPickUpAllowed(false);
        }
    }

    public GameObject getPlacedBox()
    {
        return placedBox;
    }

    public bool getLocked()
    {
        return locked;
    }

    public void setLocked(bool locked)
    {
        this.locked = locked;
    }

    public void setPlacedBox(GameObject placedBox)
    {
        this.placedBox = placedBox;
    }

    public bool hasPlacedBox()
    {
        if (placedBox) return true;
        else return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
