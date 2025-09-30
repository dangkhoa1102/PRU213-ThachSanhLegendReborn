using UnityEngine;

public class CommonerScript : MonoBehaviour
{
    enum CommonerStates { Idle, Running, Walking, Hurt }

    CommonerStates state;

    bool stateCompleted;

    void Start()
    {

    }

    void Update()
    {
        if (stateCompleted)
        {
            SelectState();
        }
        ChangeState();
    }

    void ChangeState()
    {
        switch (state)
        {
            case CommonerStates.Idle:
                IdleBehavior();
                break;
            case CommonerStates.Running:
                RunningBehavior();
                break;
            case CommonerStates.Walking:
                WalkingBehavior();
                break;
            case CommonerStates.Hurt:
                HurtBehavior();
                break;
        }
    }

    void IdleBehavior()
    {

    }

    void RunningBehavior()
    {
        
    }

    void WalkingBehavior()
    {

    }

    void HurtBehavior()
    {

    }

    void SelectState()
    {
        stateCompleted = false;
        //if ()
        //{
        //    state = CommonerStates.Idle;
        //}
        //else
        //{
        //    state = CommonerStates.Hurt;
        //}
    }

    
}
