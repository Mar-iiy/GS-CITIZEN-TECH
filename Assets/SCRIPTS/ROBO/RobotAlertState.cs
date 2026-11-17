using UnityEngine;

public class RobotAlertState : IRobotState
{

    private Animator animator;

    public RobotAlertState(Animator animator)
    {
        this.animator = animator;
    }

    public void Enter()
    {
        animator.Play("alert");
    }

    public void Exit()
    {

    }

    public void FixedTick()
    {

    }

    public void Tick()
    {
    
    }

    
}
