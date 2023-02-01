using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Idle : BaseState
{
    private GameObject[] waypoint = new GameObject[2];
    // public Transform[] dingo = new Transform[2];
    public float speed = 0.6f;
    GameObject player;
    public Transform transform;
    int currIndex = 0;

    GameObject wp1;
    GameObject wp2;

    public Idle(EnemySM stateMachine) : base("Idle", stateMachine)
    {
        //stateMachine = (EnemySM)stateMachine;

        transform = stateMachine.GetTransform();
        player = GameObject.FindGameObjectWithTag("Player");

        wp1 = new GameObject();
        wp2 = new GameObject();
        wp1.transform.position = new Vector3(0.379f, 0.005f, 0);
        wp2.transform.position = new Vector3(1.62f, 0.092f, 0);
        waypoint[0] = wp1;
        waypoint[1] = wp2;
    }

    public override void Enter()
    {
        base.Enter();
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

        if (Vector2.Distance(transform.position, player.transform.position) < 0.3f)
        {
            Debug.Log("time to change state...");

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