using UnityEngine;

public class RunState : State
{
    //[SerializeField]
    //[Tooltip("Tốc độ tối đa của nhân vật")]
    //[Range(0f, 20f)]
    //public float maxSpeed;

    public AnimationClip anim;

    public override void Enter()
    {
        //if (anim != null)
        animator.Play(anim.name);
        Debug.Log("Running");
    }

    public override void FrameUpdate()
    {
        float velocity_x = body.linearVelocity.x;
        animator.speed = Helpers.Map(input.maxXSpeed, 0, 1, 0, 1.6f, true);

        if (!input.grounded || Mathf.Abs(velocity_x) < 0.1f)
        {
            isComplete = true;
        }
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exit Run State");
    }

}
