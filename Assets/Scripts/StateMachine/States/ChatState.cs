using UnityEngine;

public class ChatState : GameState
{
    [SerializeField] private Chat chat;
    
    private StateMachine _cachedStateMachine;
    
    public override void EnterState(StateMachine stateMachine)
    {
        Cursor.lockState = CursorLockMode.None;
        chat.EnableInputField();
        
        _cachedStateMachine = stateMachine;
        chat.onMessageSent += MessageSent;
    }

    public override void ExitState(StateMachine stateMachine)
    {
        chat.DisableInputField();
        chat.onMessageSent -= MessageSent;
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchToPlayingState();
        }
    }
    
    public override void FixedUpdateState(StateMachine stateMachine)
    {
    }

    private void MessageSent()
    {
        SwitchToPlayingState();
    }

    private void SwitchToPlayingState()
    {
        _cachedStateMachine.SwitchState<PlayingState>();
    }
}
