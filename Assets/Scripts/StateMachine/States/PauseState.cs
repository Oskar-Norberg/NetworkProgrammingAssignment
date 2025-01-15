using UnityEngine;

public class PauseState : GameState
{
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private GameObject chatMenu;
    
    public override void EnterState(StateMachine stateMachine)
    {
        Cursor.lockState = CursorLockMode.None;
        
        pauseMenu.EnablePauseMenu();
        chatMenu.SetActive(false);
    }

    public override void ExitState(StateMachine stateMachine)
    {
        pauseMenu.DisablePauseMenu();
        chatMenu.SetActive(true);
    }

    public override void FixedUpdateState(StateMachine stateMachine)
    {
        
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            stateMachine.SwitchState<PlayingState>();
        }
    }
}
