using UnityEngine;

public class LvlManager : MonoBehaviour
{
    [SerializeField] private ChangeCamera changeCamera;
    [SerializeField] private MinigameTimer minigameTime;
    [SerializeField] private LvlTimer lvlTime;
    [SerializeField] private DayManager dayManager;


    [Header("Points")]
    [SerializeField] public int satisfactionPointsG;
    [SerializeField] public int satisfactionPointsB;


    [Header("EndScreen")]
    [SerializeField] public GameObject[] endScreen;


    public int minigameDayCount;
    public  bool minigameIsOn;

    
    void Start()
    {
        minigameDayCount = 0;

        endScreen[0].SetActive(false);
        endScreen[1].SetActive(false);
    }

    public void EndLevel()
    {

        Debug.Log("END LEVEL CALLED");
        Debug.Log("CURRENT DAY: " + dayManager.dayNumber);
        Debug.Log("MINIGAMES COMPLETED: " + minigameDayCount);

        if (dayManager.dayNumber >= 4)
        {
            Debug.Log("CALLING END WEEK");
            dayManager.CallEndWeek();
        }

        else
        {
            Debug.Log("CALLING NORMAL END SCREEN");

            if (satisfactionPointsG > satisfactionPointsB)
            {
                endScreen[0].SetActive(true);
            }
            else
            {
                endScreen[1].SetActive(true);
            }

            lvlTime.PauseTimer();
        }

        minigameDayCount = 0;

    }

   public void ResetDayPoints()
   {
        satisfactionPointsB = 0;
        satisfactionPointsG = 0;
   }

    public void StartMinigame()
    {

        if (minigameDayCount >= 5)
        {
            return;
        }

        minigameIsOn = true;
        minigameTime.StartTimer();

        minigameDayCount++;

        Debug.Log("MINIGAME INICIADO");

    }



    public void EndMinigame()
    {
        minigameIsOn = false;
        minigameTime.StopTimer();

        changeCamera.ActivateCamera(0);

        if (minigameDayCount >= 5)
        {
            EndLevel();
            return;
        }

        lvlTime.ResumeTimer();
    }


}
