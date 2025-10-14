using UnityEngine;

public class IdleState : State
{

    public AnimationClip anim;
    public override void Enter()
    {
        animator.Play(anim.name);
    }

    public override void FrameUpdate()
    {
        if (!input.grounded)
        {
            isComplete = true;
        }
        else if (input.xInput != 0)
        {
            isComplete = true;
        }
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exit Idle State");
    }
}
