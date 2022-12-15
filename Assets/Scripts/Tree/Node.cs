using System;
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
        if (locked)
        {
            try
            {
                GameObject label = placedBox.transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
                label.GetComponent<SpriteRenderer>().color = new Color(0.3910296f, 1f, 0.3820755f, 1f);
            }
            catch (Exception) { }
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

            //GameObject.Find("GameController").GetComponent<LevelController>().setArry(transform.parent.GetComponent<TreeToArray>().getArray());
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
