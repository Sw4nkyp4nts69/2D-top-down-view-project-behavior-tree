using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySM : StateMachine
{
    //[HideInInspector]
    [HideInInspector]
    private Idle st_idle; // IDLE STATE
    [HideInInspector]
    //public Chase st_chase; // CHASE STATE

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