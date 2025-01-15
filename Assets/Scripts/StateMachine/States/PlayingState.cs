using UnityEngine;

public class PlayingState : GameState
{
    [Header("Managers")] 
    [SerializeField] private PlayerManager playerManager;
    
    public override void EnterState(StateMachine stateMachine)
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState(StateMachine stateMachine)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        playerManager.CustomUpdate(Time.deltaTime);
    }
    
    public override void FixedUpdateState(StateMachine stateMachine)
    {
        playerManager.CustomFixedUpdate(Time.fixedDeltaTime);
    }
}
