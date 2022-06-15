using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float speed = 1f;
    public float jumpForce = 3f;
    private bool canJump = true;
    public Vector2 ballSpawnOffset;
    public GameObject ballPrefab;

    private float horizontal;
    
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("movementX", horizontal);
        if (Input.GetButtonDown("Jump") && canJump) Jump();
        if (Input.GetKeyDown(KeyCode.F)) 
            ThrowBall();

    }

    void Jump()
    {
        
        rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        canJump = false;
        
    }

    void ThrowBall()
    {

        Vector3 spawnPos = ballSpawnOffset;
        if (horizontal < 0) spawnPos.x *= -1;
        if (horizontal == 0)
        {

            spawnPos.x = 0;
            spawnPos.y *= 2;

        }

        GameObject ball = Instantiate(ballPrefab, transform.position + spawnPos, Quaternion.identity);

        Vector2 direction = new Vector2(0, 0);
        if (horizontal > 0) direction.x = 25;
        else if (horizontal < 0) direction.x = -25;
        else direction.y = 15;
        
        BallController controller = ball.GetComponent<BallController>();
        controller.SetDirection(direction);

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
