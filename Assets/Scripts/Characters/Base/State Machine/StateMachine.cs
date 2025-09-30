using UnityEngine;

public class StateMachine 
{
    public State CurrentState { get; set; }

    public void Initialize(State startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }
    public void ChangeState(State newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
    public void FrameUpdate()
    {
        CurrentState.FrameUpdate();
    }
    public void PhysicsUpdate()
    {
        CurrentState.PhysicsUpdate();
    }
    public void TriggerEvent()
    {
        CurrentState.TriggerEvent();
    }

}
