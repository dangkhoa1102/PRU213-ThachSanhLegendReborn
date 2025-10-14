using UnityEngine;

public class AirState : State
{
    [Tooltip("Tốc độ nhảy của nhân vật")]
    [Range(0f, 20f)]
    public float jumpSpeed;

    public AnimationClip anim;

    override public void Enter()
    {
        //if (anim != null) 
        animator.Play(anim.name);
    }

    override public void FrameUpdate()
    {
        float time = Helpers.Map(body.linearVelocity.y, input.jumpSpeed, -input.jumpSpeed, 0, 1, true);
        animator.Play(anim.name, 0, time);
        animator.speed = 0;

        if (input.grounded)
        {
            isComplete = true;
        }
    }

    override public void Exit()
    {
        base.Exit();
        Debug.Log("Exit Air State");
    }
}
