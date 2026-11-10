using NUnit.Framework.Constraints;
using System;
using TMPro;
using UnityEngine;

public class MinigameTimer : MonoBehaviour
{
    [SerializeField] private LvlManager lvlManager;
    [SerializeField] WinLoseMinigame winOrLose;

    [Header("Timer Settings")]
    [SerializeField] private TMP_Text timerText;
    [SerializeField] public float currentTime;
    [SerializeField] private bool active;


    private void Start()
    {
        timerText.gameObject.SetActive(false);
        active = false;
    }

    private void Update()
    {
        if (!active)
        {
            return;
        }

        currentTime -= Time.deltaTime;

        timerText.text = ("00:" + Mathf.CeilToInt(currentTime).ToString());

        if (currentTime <= 0f)
        {
            Debug.Log("TEMPO MINIGAME ACABOU");

            currentTime = 0f;
            active = false;

            timerText.text = "00:00";

            winOrLose.LoseMinigame();
        }
    }

    public void StopTimer()
    {
        Debug.Log("TIMER DESATIVADO");

        active = false;
        currentTime = 0;

        timerText.gameObject.SetActive(false);
       
    }

    public void StartTimer()
    {
        Debug.Log("TIMER ATIVADO");

        active = true;
        currentTime = 15f;
      
        timerText.gameObject.SetActive(true);


        timerText.text = ("00:" + Mathf.CeilToInt(currentTime).ToString());
    }

}

