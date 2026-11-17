using UnityEngine;

public interface IRobotState 
{
    void Enter();
    void Tick();
    void FixedTick();
    void Exit();

    public class RobotStateMachine
    {
        public IRobotState currentState { get; private set; }

        public void ChangeState(IRobotState newstate)
        {
            currentState?.Exit();
            currentState = newstate;
            currentState.Enter();
        }

        public void Tick() => currentState?.Tick();
        public void FixedTick() => currentState?.FixedTick();
    }
}
