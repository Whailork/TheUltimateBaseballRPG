using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class YankeeController : EnemyBase
{

    private float moveSpeed;

    public YankeeController(float speed)
    {

        moveSpeed = speed;

    }


    public override void Start(Rigidbody2D rb)
    {
        
        enemy.StartCoroutine(MovementCoroutine(rb));
        
    }

    public override void UpdateMovement(Rigidbody2D rb) { }

    IEnumerator MovementCoroutine(Rigidbody2D rb)
    {

        while (true)
        {
            
            float timeChange = Random.Range(2f, 5f);

            Vector2 movement = Vector2.zero;
            movement.x = Random.Range(-1, 2);
            rb.velocity = movement * moveSpeed;
            yield return new WaitForSeconds(timeChange);
            
        }

    }
    
}
