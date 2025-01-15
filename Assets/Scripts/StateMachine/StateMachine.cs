using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private List<GameState> states = new List<GameState>();
    private GameState currentState;

    private void Start()
    {
        // Start in PlayingState
        SwitchState<PlayingState>();
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
