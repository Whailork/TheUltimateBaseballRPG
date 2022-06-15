using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 1f;
    public float jumpForce = 3f;
    private bool canJump = true;

    private float horizontal;
    
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && canJump) Jump();

    }

    void Jump()
    {
        
        rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        canJump = false;
        
    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(horizontal*speed, rb.velocity.y);
        
        if (rb.velocity.y <= 0 && Physics2D.Raycast(transform.position, Vector3.down, 0.1f, LayerMask.GetMask("Floor")))
        {

            canJump = true;

        }
        
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(transform.position, transform.position + (Vector3.down*0.2f));
        
    }
}
