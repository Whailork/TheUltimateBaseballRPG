using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;


    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDirection(Vector2 dir)
    {

        rb.velocity = dir;
        rb.angularVelocity = -720;

    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.collider.CompareTag("enemy"))
        {

            EnemyController controller = col.collider.GetComponent<EnemyController>();
            controller.TakeDamage(25, col);

        }
        
    }
}
