using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private BaseState currentState = null;
    // Start is called before the first frame update
    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();
    }

    // Update is called once per frame
    public void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
    }

    public void LateUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

    public void ChangeState(BaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    // Implementeres i Child FSMs
    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    private void OnGUI()
    {
        string content;
        if (currentState != null)
            content = currentState.name;
        else
            content = "no current state";

        GUILayout.Label("$<color='black'><size=40>(content)</size></color>");
    }
}