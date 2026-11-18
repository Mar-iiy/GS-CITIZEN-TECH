using UnityEngine;
using System.Collections;

public class SecurityScreen : MonoBehaviour
{
    private Collider2D col;
    private SpriteRenderer sr;
    private Coroutine stateRoutine;

    [SerializeField] private ChangeCamera changeCamera;
    [SerializeField] private LvlManager lvlManager;
    [SerializeField] private pauseManager pause;

    // [SerializeField] Sprite[] spritesStates;


    [Header("Timer")]
    [SerializeField] private float minTimer;
    [SerializeField] private float maxTimer;
    [SerializeField] private float onTimer;

    [Header("State")]
    public bool isAlarmOn;
    [SerializeField] public static int intID;

    void Start()
    {
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();

        isAlarmOn = false;
        CheckState();
    }
    void CheckState()
    {
        if (stateRoutine != null)
        {
            StopCoroutine(stateRoutine);
            stateRoutine = null;
        }

        if (isAlarmOn)
        {
            AlertOn();
        }
        else
        { 
            AlertOff(); 
        }
    }

    void AlertOn()
    {
        sr.color = Color.red;
        intID = Random.Range(1, 5); 
        //intID = 2;
        stateRoutine = StartCoroutine(AlertOnRoutine());
    }

    IEnumerator AlertOnRoutine()
    {
        yield return new WaitForSeconds(onTimer);

        isAlarmOn = false;
        CheckState();
    }


    void AlertOff()
    {
        sr.color = Color.grey;
        intID = 0;
        stateRoutine = StartCoroutine(AlertOffRoutine());
    }

    IEnumerator AlertOffRoutine()
    {
        float wait = Random.Range(minTimer, maxTimer);
        yield return new WaitForSeconds(wait);

        isAlarmOn = true;
        CheckState();
    }

    private void OnMouseDown()
    {
        if(isAlarmOn && pause.gamePaused == false)
        {
            Debug.Log("FOI CLICADO");
            changeCamera.ActivateCamera(intID);
            AlertOff();
            lvlManager.StartMinigame();
        }

        else
        {
            Debug.Log("NAO PODE CLICAR AINDA");
        }
    }
}
