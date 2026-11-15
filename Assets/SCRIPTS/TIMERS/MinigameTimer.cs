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
    [SerializeField] private GameObject timerPanel;
    [SerializeField] public float currentTime;
    [SerializeField] private bool active;


    private void Start()
    {
        timerPanel.SetActive(false);

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

        timerText.text = ("00:" + Mathf.CeilToInt(currentTime).ToString("00"));

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

        timerPanel.SetActive(false);
        timerText.gameObject.SetActive(false);
    }

    public void StartTimer()
    {
        Debug.Log("TIMER ATIVADO");

        active = true;
        currentTime = 15f;

        timerPanel.SetActive(true);
        timerText.gameObject.SetActive(true);
       
        timerText.text = ("00:" + Mathf.CeilToInt(currentTime).ToString());
    }

}

