using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private List<GameState> states = new List<GameState>();
    private GameState currentState;

    private void Start()
    {
        
        // TODO: Fix
        // Start in Playing Game State
        //SwitchState<PlayingGameState>();
    }

    public void SwitchState<TNextState>()
    {
        foreach (GameState state in states)
        {
            if (state.GetType() == typeof(TNextState))
            {
                currentState?.ExitState(this);
                currentState = state;
                state.EnterState(this);
                return;
            }
        }
        Debug.Log("State not found");
    }

    private void Update()
    {
        currentState?.UpdateState(this);
    }

    private void FixedUpdate()
    {
        currentState?.FixedUpdateState(this);
    }
}
