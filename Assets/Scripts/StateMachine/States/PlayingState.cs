using UnityEngine;

public class PlayingState : GameState
{
    public override void EnterState(StateMachine stateMachine)
    {
        Debug.Log("Entered PlayingState");
    }

    public override void ExitState(StateMachine stateMachine)
    {
        Debug.Log("Exit PlayingState");
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        PlayerManager.Instance.CustomUpdate(Time.deltaTime);
    }
    
    public override void FixedUpdateState(StateMachine stateMachine)
    {
        PlayerManager.Instance.CustomFixedUpdate(Time.fixedDeltaTime);
    }
}
