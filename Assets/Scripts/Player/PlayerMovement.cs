using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;

    float moveSpeed = 5f;
    float speedLimiter = 0.7f;
    private Vector2 moveInput;

    private PickUp pickUp;

    void Start()
    {
        pickUp = gameObject.GetComponent<PickUp>();
        pickUp.Direction = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if (moveInput.sqrMagnitude > .1f) //PickUp Genauigkeit
        {
            pickUp.Direction = moveInput.normalized * .3f; //PickUp Länge
        }

        //Animation
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
    }

    void FixedUpdate()
    {
        if (moveInput.x != 0 || moveInput.y != 0)
        {
            if (moveInput.x != 0 && moveInput.y != 0)
            {
                moveInput.x *= speedLimiter;
                moveInput.y *= speedLimiter;
            }
            rb.velocity = moveInput * moveSpeed;
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }
    }
}

