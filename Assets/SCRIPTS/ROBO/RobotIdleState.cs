using UnityEngine;

public class RobotIdleState : IRobotState
{
    private Animator animator;

    public RobotIdleState(Animator animator)
    {
        this.animator = animator;
    }

    public void Enter()
    {
        animator.Play("idle");
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
