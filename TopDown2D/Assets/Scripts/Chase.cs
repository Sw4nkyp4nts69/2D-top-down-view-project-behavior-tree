using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Chase : BaseState
{
    public float speed = 0.6f;
    GameObject player;
    public Transform transform;
    


    public Chase(EnemySM stateMachine) : base("Chase", stateMachine)
    {
        //stateMachine = (EnemySM)stateMachine;

        transform = stateMachine.GetTransform();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("The state has been changed");
    }


    //=== OPDATERER LOGIK =====================================================
    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (Vector2.Distance(transform.position, player.transform.position) < 0.6f)
        {
            Debug.Log("time to change state....");
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        
    }

    public override void Exit()
    {
        base.Exit();
    }
}