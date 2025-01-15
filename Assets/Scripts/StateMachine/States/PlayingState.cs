using UnityEngine;

public class PlayingState : GameState
{
    public override void EnterState(StateMachine stateMachine)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Entered PlayingState");
    }

    public override void ExitState(StateMachine stateMachine)
    {
        Debug.Log("Exit PlayingState");
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            stateMachine.SwitchState<ChatState>();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            stateMachine.SwitchState<PauseState>();
        }
        
        PlayerManager.Instance.CustomUpdate(Time.deltaTime);
    }
    
    public override void FixedUpdateState(StateMachine stateMachine)
    {
        PlayerManager.Instance.CustomFixedUpdate(Time.fixedDeltaTime);
    }
}
