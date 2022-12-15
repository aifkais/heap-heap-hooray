using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdSpot;
    
    public Vector3 Direction { get; set; }
    public LayerMask pickUpMask;
    private GameObject itemHolding;

    void Update()
    {
        holdSpot.position = GetComponent<PlayerMovement>().getIdleSpot().position;
        if (holdSpot.position == transform.Find("IdleSpots").Find("Top").position && itemHolding) //wenn vorne
        {
            itemHolding.GetComponent<SpriteRenderer>().sortingOrder = 1;
        } 
        else if (itemHolding)
        {
            itemHolding.GetComponent<SpriteRenderer>().sortingOrder = 3;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itemHolding)
            {
                itemHolding.transform.position = transform.position + Direction;
                itemHolding.transform.parent = GameObject.Find("BoxParent").transform;

                if (itemHolding.GetComponent<Rigidbody2D>())
                    itemHolding.GetComponent<Rigidbody2D>().simulated = true;

                itemHolding = null;
            }
            else
            {
                Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .6f, pickUpMask);
                if (pickUpItem && pickUpItem.GetComponent<Box>().getPickUpAllowed())
                {
                    itemHolding = pickUpItem.gameObject;
                    itemHolding.transform.position = holdSpot.position;
                    itemHolding.transform.parent = transform.GetChild(0);

                    if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                }
            }
        }
    }
}
