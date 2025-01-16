using UnityEngine;

public class EnterNameState : GameState
{
    [SerializeField] private EnterName enterName;
    
    private StateMachine _stateMachine;
    
    public override void EnterState(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        enterName.onNameEntered += NameEntered;
    }

    public override void ExitState(StateMachine stateMachine)
    {
        enterName.Disable();
        enterName.onNameEntered -= NameEntered;
    }

    private void NameEntered()
    {
        _stateMachine.SwitchState<PlayingState>();
    }

    public override void FixedUpdateState(StateMachine stateMachine)
    {
    }

    public override void UpdateState(StateMachine stateMachine)
    {
    }
}
