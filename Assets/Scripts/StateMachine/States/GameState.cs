using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState : MonoBehaviour
{ 
    public abstract void EnterState(StateMachine stateMachine);
    
    public abstract void ExitState(StateMachine stateMachine);
    
    public abstract void FixedUpdateState(StateMachine stateMachine);

    public abstract void UpdateState(StateMachine stateMachine);
}
