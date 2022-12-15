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
    private bool canMove = false;
    private Transform currentIdleSpot;

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
        if (canMove)
        {
            animator.SetFloat("Horizontal", moveInput.x);
            animator.SetFloat("Vertical", moveInput.y);
        }
    }

    void FixedUpdate()
    {
        if (canMove)
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

    public Transform getIdleSpot()
    {
        //AutoAttackWeapon
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Walk_Right"))
        {
            currentIdleSpot = transform.Find("IdleSpots").Find("Right");
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Walk_Left"))
        {
            currentIdleSpot = transform.Find("IdleSpots").Find("Left");
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Walk_Up"))
        {
            currentIdleSpot = transform.Find("IdleSpots").Find("Top");
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Walk_Down"))
        {
            currentIdleSpot = transform.Find("IdleSpots").Find("Bottom");
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle"))
        {
            currentIdleSpot = transform.Find("IdleSpots").Find("Bottom");
        }
        return currentIdleSpot;
    }

    public void setCanMove(bool canMove)
    {
        this.canMove = canMove;
    }
}

