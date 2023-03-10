using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Idle : BaseState
{
    private GameObject[] waypoint = new GameObject[4];
    // public Transform[] dingo = new Transform[2];
    public float speed = 0.6f;
    GameObject player;
    public Transform transform;
    int currIndex = 0;

    GameObject wp1;
    GameObject wp2;
    GameObject wp3;
    GameObject wp4;

    public Idle(EnemySM stateMachine) : base("Idle", stateMachine)
    {
        //stateMachine = (EnemySM)stateMachine;

        transform = stateMachine.GetTransform();
        player = GameObject.FindGameObjectWithTag("Player");

        wp1 = new GameObject();
        wp2 = new GameObject();
        wp3 = new GameObject();
        wp4 = new GameObject();
        wp1.transform.position = new Vector3(0.185f, 0.459f, 0);
        wp2.transform.position = new Vector3(1.4f, 0.459f, 0);
        wp3.transform.position = new Vector3(1.4f, -0.153f, 0);
        wp4.transform.position = new Vector3(0.185f, -0.153f, 0);
        waypoint[0] = wp1;
        waypoint[1] = wp2;
        waypoint[2] = wp3;
        waypoint[3] = wp4;
    }

    public override void Enter()
    {
        base.Enter();
        ((EnemySM)stateMachine).spriteRenderer.color = Color.white;
    }


    //=== OPDATERER LOGIK =====================================================
    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (Vector2.Distance(transform.position, waypoint[currIndex].transform.position) < 0.1f)
        {
            currIndex++;
            if (currIndex >= waypoint.Length)
            {
                currIndex = 0;
            }
        }

        if (Vector2.Distance(transform.position, player.transform.position) < 1f)
        {
            Debug.Log("time to change state to chase");
            stateMachine.ChangeState(((EnemySM)stateMachine).st_chase);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        if (currIndex < waypoint.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint[currIndex].transform.position, speed * Time.deltaTime);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}