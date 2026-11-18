using UnityEngine;
using static IRobotState;

public class RobotStateController : MonoBehaviour
{
    private SecurityScreen screen;
    [SerializeField] private Animator animator;

    [SerializeField] GameObject[] sScreens;

    private RobotStateMachine stateMachine;

    private RobotAlertState alertState;
    private RobotIdleState idleState;


    void Start()
    {
        stateMachine = new RobotStateMachine();

        alertState = new RobotAlertState(animator);
        idleState = new RobotIdleState(animator);

        stateMachine.ChangeState(idleState);
    }

    private void Update()
    {
        CheckRobotState();
        stateMachine.Tick();
    }

    private void FixedUpdate()
    {
        stateMachine.FixedTick();
    }

    private void CheckRobotState()
    {
        foreach (GameObject obj in sScreens)
        {
            SecurityScreen securityScreens = obj.GetComponent<SecurityScreen>();

            if (securityScreens == null)
            {
                continue;
            }

            if (securityScreens.isAlarmOn)
            {

                if (stateMachine.currentState != alertState)
                {
                    Debug.Log("STATE ALERTA");
                    stateMachine.ChangeState(alertState);
                }

                return;
            }
        }

        // No screens have an active alarm
        if (stateMachine.currentState != idleState)
        {
            stateMachine.ChangeState(idleState);
        }
    }

}


