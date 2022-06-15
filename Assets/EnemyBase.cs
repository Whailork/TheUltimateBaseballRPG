using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class EnemyBase
{
    protected EnemyController enemy;

    public void SetEnemyController(EnemyController c)
    {

        enemy = c;

    }

    public abstract void Start(Rigidbody2D rb);
    
    public abstract void UpdateMovement(Rigidbody2D rb);

}
