using UnityEngine;

public class GameManager : StateMachine
{
    private void Start()
    {
        // Start in Enter Name State
        SwitchState<EnterNameState>();
    }
}
