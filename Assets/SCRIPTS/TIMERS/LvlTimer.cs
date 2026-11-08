using TMPro;
using UnityEngine;

public class LvlTimer : MonoBehaviour
{
    [SerializeField] private LvlManager lvlmanager;

    [Header("Settings")]
    [SerializeField] private int startHour;
    [SerializeField] private int startMinute = 0;
    [SerializeField] private int endHour;

    [Header("Timer")]
    [SerializeField] private float secondsPerMinute;

    [Header("UI")]
    [SerializeField] private TMP_Text timerText;

    private int currentHour;
    private int currentMinute;

    private float timer;
    private bool clockRunning = true;

    void Start()
    {
        currentHour = startHour;
        currentMinute = startMinute;

        UpdateClockDisplay();
    }

    void Update()
    {
        if (!clockRunning)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= secondsPerMinute)
        {
            timer -= secondsPerMinute;
            AdvanceMinute();
        }
    }

    public void AdvanceMinute()
    {
        currentMinute++;

        if (currentMinute >= 60)
        {
            currentMinute = 0;
            currentHour++;
        }

        UpdateClockDisplay();

        if (currentHour >= endHour && currentMinute == 0)
        {
            clockRunning = false;
            Debug.Log("FIM DA FASE");
            lvlmanager.EndLevel();
        }
    }

    public void PauseTimer()
    {
        clockRunning = false;
        Debug.Log("TIMER PAUSADO");
    }

    public void ResumeTimer()
    {
        clockRunning = true;
        Debug.Log("TIMER CONTINUADO");
    }

    void UpdateClockDisplay()
    {
        timerText.text = $"{currentHour:00}:{currentMinute:00}";
    }
}
