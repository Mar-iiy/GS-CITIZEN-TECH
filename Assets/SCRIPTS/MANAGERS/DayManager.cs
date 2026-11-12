using UnityEngine;

public class DayManager : MonoBehaviour
{
    [SerializeField] private LvlManager lvlManager;
    [SerializeField] private LvlTimer lvlTimer;
    [SerializeField] private TutorialDialogue tutorialDialogue;


    [Header("WeekPoints")]
    [SerializeField] int weekSatisfactionG;
    [SerializeField] int weekSatisfactionB;

    [Header("WeekDay")]
    [SerializeField] int dayNumber;

    [Header("WeekEnd")]
    [SerializeField] private GameObject[] weekEnding;
    
    void Start()
    {
        dayNumber = 0;
        
        weekEnding[0].SetActive(false);
        weekEnding[1].SetActive(false);
    }

    void Update()
    {
        
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

        if (dayNumber == 5)
        {
            CallEndWeek();
        }

        switch (dayNumber)
        {
            case 1:
                lvlTimer.SetDayTime(13, 0, 17);
                break;

            case 2:
                lvlTimer.SetDayTime(6, 0, 9);
                break;

            case 3:
                lvlTimer.SetDayTime(9, 0, 12);
                break;

            case 4:
                lvlTimer.SetDayTime(18, 0, 20);
                break;
        }

        tutorialDialogue.SetDialogueGroup(dayNumber);
    }

    void CallEndWeek()
    {
        if(weekSatisfactionG > weekSatisfactionB)
        {
            weekEnding[0].SetActive(true);
        }

        else 
        {
            weekEnding[1].SetActive(true);
        }
    }
}
