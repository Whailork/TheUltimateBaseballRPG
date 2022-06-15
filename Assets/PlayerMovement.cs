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
    
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x*speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && canJump)
        {
            
            rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
            
        }

    }

    private void FixedUpdate()
    {
        
        //check si on peut Sauter
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.2f, LayerMask.GetMask("Floor")))
        {
            
            Debug.Log("PLANCHER!");
            
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.down*0.2f));
        
    }
}
