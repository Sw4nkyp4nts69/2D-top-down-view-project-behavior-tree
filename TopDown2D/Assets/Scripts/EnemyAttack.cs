using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyAttack : BaseState
{
    public float speed = 0.6f;
    GameObject player;
    public Transform transform;
    



    public EnemyAttack(EnemySM stateMachine) : base("EnemyAttack", stateMachine)
    {
        //stateMachine = (EnemySM)stateMachine;

        transform = stateMachine.GetTransform();
        player = GameObject.FindGameObjectWithTag("Player");        

    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("The state has been changed from Chase to attack");
        ((EnemySM)stateMachine).spriteRenderer.color = Color.red;
    }


    //=== OPDATERER LOGIK =====================================================
    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (Vector2.Distance(transform.position, player.transform.position) > 0.6f)
        {
            Debug.Log("time to change state....");
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            stateMachine.ChangeState(((EnemySM)stateMachine).st_idle);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        player = GameObject.FindGameObjectWithTag("Player");

    }

    public override void Exit()
    {
        base.Exit();
    }
}