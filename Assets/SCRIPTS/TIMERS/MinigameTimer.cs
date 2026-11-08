using UnityEngine;
using TMPro;

public class MinigameTimer : MonoBehaviour
{
    [SerializeField] private LvlManager lvlManager;
    [SerializeField] WinLoseMinigame winOrLose;

    [Header("Timer Settings")]
    [SerializeField] private float minigameDuration = 15f;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float timer;
    [SerializeField] private bool timerRunning;

    private void Start()
    {
        timerRunning = false;

        timerText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!timerRunning)
        { 
            return; 
        }

        timer -= Time.deltaTime;

        timerText.text = Mathf.CeilToInt(timer).ToString();

        if (timer <= 0)
        {
            timer = 0;

            StopTimer();
            winOrLose.LoseMinigame();
        }
    }

    public void StartTimer()
    {
        timer = minigameDuration;

        timerRunning = true;

        timerText.gameObject.SetActive(true);
        timerText.text = Mathf.CeilToInt(timer).ToString();

        Debug.Log("TIMER DO MINIGAME INICIADO");
    }

    public void StopTimer()
    {
        timerRunning = false;
        timerText.gameObject.SetActive(false);
    }
}
