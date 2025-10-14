using UnityEngine;

public abstract class State : MonoBehaviour
{   
    public bool isComplete { get; protected set; }

    protected float startTime;

    public float time => Time.time - startTime;

    protected Rigidbody2D body;
    protected Animator animator;
    protected PlayerMovement input;


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

    public void Setup(Rigidbody2D _body, Animator _animator, PlayerMovement _movement)
    {
        animator = _animator;
        body = _body;
        input = _movement;
    }
}
