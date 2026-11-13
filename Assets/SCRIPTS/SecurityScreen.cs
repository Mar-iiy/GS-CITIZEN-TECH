using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class SecurityScreen : MonoBehaviour
{
    private Collider2D col;
    private SpriteRenderer sr;
    private Coroutine stateRoutine;

    [SerializeField] private ChangeCamera changeCamera;
    [SerializeField] private LvlManager lvlManager;

    // [SerializeField] Sprite[] spritesStates;


    [Header("Timer")]
    [SerializeField] private float minTimer;
    [SerializeField] private float maxTimer;
    [SerializeField] private float onTimer;

    [Header("State")]
    bool isAlarmOn;
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
        //checar se isAlarOn esta true ou false
        // se false iniciar void para true 
        // se true o contrario 

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
        //roda se isAlertOn == true
        // muda sprite/animacao para alertaLigado
        //intID == valor aleatorio (1-8)
        //permanece ligado por 10 segundos se nao for clicado
        //depois dos 10 segundo isAlertOn == false e checkState é chamado

        sr.color = Color.red;
        //intID = Random.Range(1, 4); 
        intID = 1;
        stateRoutine = StartCoroutine(AlertOnRoutine());
    }

    IEnumerator AlertOnRoutine()
    {
        yield return new WaitForSeconds(onTimer);

        // não foi clicado a tempo
        isAlarmOn = false;
        CheckState();
    }


    void AlertOff()
    {
        //roda se isAlertOn == false
        //muda sprite/animacao para alertaDesligado
        // intId == 0
        //inicia corrotina com tempo sorteado aleatorio entre minTimer-maxTimer
        // no final do timer isAlertOn == true e checkState é chamado

        sr.color = Color.grey;
        intID = 0;
        stateRoutine = StartCoroutine(AlertOffRoutine());
    }

    IEnumerator AlertOffRoutine()
    {
        //espera o tempo aleatorio pra ligar de novo
        
        float wait = Random.Range(minTimer, maxTimer);
        yield return new WaitForSeconds(wait);

        isAlarmOn = true;
        CheckState();
    }

    private void OnMouseDown()
    {
        if(isAlarmOn)
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
