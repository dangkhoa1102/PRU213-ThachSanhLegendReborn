using UnityEngine;

public class State
{
    protected GameObject _entity;
    protected StateMachine _stateMachine;

    public State(GameObject entity, StateMachine stateMachine)
    {
        _entity = entity;
        _stateMachine = stateMachine;
    }

    public virtual void Enter()
    {

    }
    public virtual void Exit()
    {
    }
    public virtual void FrameUpdate()
    {
    }
    public virtual void PhysicsUpdate()
    {
    }

    public virtual void TriggerEvent()
    {
    }
}
