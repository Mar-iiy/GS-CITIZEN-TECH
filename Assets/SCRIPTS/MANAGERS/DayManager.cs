using UnityEngine;

public class DayManager : MonoBehaviour
{
    [SerializeField] private LvlManager lvlManager;
    [SerializeField] private LvlTimer lvlTimer;
    [SerializeField] private MinigameTimer mgTimer;
    [SerializeField] private TutorialDialogue tutorialDialogue;


    [Header("WeekPoints")]
    [SerializeField] int weekSatisfactionG;
    [SerializeField] int weekSatisfactionB;

    [Header("WeekDay")]
    [SerializeField] int dayNumber;

    [Header("WeekEnd")]
    [SerializeField] private GameObject[] weekEnding;

    [Header("animator")]
    [SerializeField] Animator animator;

    [SerializeField] private AudioClip audioItem;
    [SerializeField] private AudioSource audio;

    void Start()
    {
        dayNumber = 0;
        
        weekEnding[0].SetActive(false);
        weekEnding[1].SetActive(false);
    }

    void Awake()
    {
        Hello();
    }

    public void CallNextDay()
    {
        dayNumber++;

        weekSatisfactionG += lvlManager.satisfactionPointsG;
        weekSatisfactionB += lvlManager.satisfactionPointsB;

        ChangeDay();

    }

    void ChangeDay()
    {

        foreach (GameObject endScreen in lvlManager.endScreen)
        {
            endScreen.SetActive(false);
        }

        lvlManager.ResetDayPoints();

        Hello();

        if (dayNumber == 5)
        {
            CallEndWeek();
        }

        switch (dayNumber)
        {
            case 1:
                lvlTimer.SetDayTime(13, 0, 15);
                mgTimer.SetTimerTime(30f);
                break;

            case 2:
                lvlTimer.SetDayTime(6, 0, 9);
                mgTimer.SetTimerTime(30f);
                break;

            case 3:
                lvlTimer.SetDayTime(9, 0, 12);
                mgTimer.SetTimerTime(15f);
                break;

            case 4:
                lvlTimer.SetDayTime(18, 0, 20);
                mgTimer.SetTimerTime(15f);
                break;
        }

        tutorialDialogue.SetDialogueGroup(dayNumber);
    }

    public void Hello()
    {
        audio.clip = audioItem;
        audio.Play();
        animator.Play("hello");
    }

    void CallEndWeek()
    {
        if(weekSatisfactionG > weekSatisfactionB)
        {
            weekEnding[0].SetActive(true);
        }

        if(weekSatisfactionG < weekSatisfactionB || weekSatisfactionG == 0)
        {
            weekEnding[1].SetActive(true);
        }
    }
}
