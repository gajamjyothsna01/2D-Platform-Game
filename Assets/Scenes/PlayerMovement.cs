using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     public float playerJumpForce; //to put the values in editor
     public float playerSpeed; //change from editor
     Rigidbody2D rb;
    bool isFacingRight;
    bool isPlayerGrounded;
    float xInput, yInput;
    public LayerMask layerMask;
    public Transform groundCheck; //checking for whether it is grounded or not
    public float checkRadius;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true; //By default the player is looking at right.
        
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius,layerMask);
        xInput = Input.GetAxis("Horizontal"); //To move horizontally from left to right and right to left
        rb.velocity = new Vector2(xInput * playerSpeed, rb.velocity.y);
        if(isFacingRight == false && xInput > 0) //player is not facing right and x input > 0
        {
            Flip();
        }
        else if(isFacingRight == true && xInput < 0)
        {
            Flip();
        }
        if(Input.GetButtonDown("Fire1") && isPlayerGrounded == true)
        {
            rb.velocity = Vector2.up * playerJumpForce;

        }

    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0); //Rotating 180 degrees
    }
    
}
