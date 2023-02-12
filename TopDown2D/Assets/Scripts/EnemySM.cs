using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySM : StateMachine
{
    //[HideInInspector]
    [HideInInspector]
    public Idle st_idle; // IDLE STATE
    [HideInInspector]
    public Chase st_chase; // CHASE STATE
    public EnemyAttack st_enemyAttack;
    public SpriteRenderer spriteRenderer;

    public void Awake()
    {
        st_idle = new Idle(this);
    }

    public Transform GetTransform()
    {
        return transform;
    }

    protected override BaseState GetInitialState()
    {
        return st_idle;
    }

}