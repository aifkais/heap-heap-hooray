using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdSpot;
    
    public Vector3 Direction { get; set; }
    public LayerMask pickUpMask;
    private GameObject itemHolding;

    private bool pickUpAllowed;

    void Update()
    {
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
                    itemHolding.transform.parent = transform;

                    if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                }
            }
        }
    }
}
