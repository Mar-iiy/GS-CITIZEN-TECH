using UnityEngine;
using UnityEngine.Rendering;

public class LvlManager : MonoBehaviour
{
    [SerializeField] private ChangeCamera changeCamera;
    [SerializeField] private MinigameTimer minigameTime;
    [SerializeField] private LvlTimer lvlTime;


    [Header("Points")]
    [SerializeField] public int satisfactionPointsG;
    [SerializeField] public int satisfactionPointsB;


    [Header("EndScreen")]
    [SerializeField] public GameObject[] endScreen;

    public  bool minigameIsOn;

    
    void Start()
    {
        endScreen[0].SetActive(false);
        endScreen[1].SetActive(false);
    }

    public void EndLevel()
    {
        if (satisfactionPointsG > satisfactionPointsB)
        {
            endScreen[0].SetActive(true);
            lvlTime.PauseTimer();
            satisfactionPointsG = 0;
        }

        else
        {
            endScreen[1].SetActive(true);
            lvlTime.PauseTimer();
            satisfactionPointsB = 0;
        }
    }

    public void StartMinigame()
    {
        minigameIsOn = true;
        minigameTime.StartTimer();
        Debug.Log("MINIGAME INICIADO");
    }

    public void EndMinigame()
    {
        minigameIsOn = false;
        minigameTime.StopTimer();
        changeCamera.ActivateCamera(0);
        lvlTime.ResumeTimer();
    }
}
