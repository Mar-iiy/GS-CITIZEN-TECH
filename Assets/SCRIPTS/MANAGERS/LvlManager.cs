using UnityEngine;
using UnityEngine.Rendering;

public class LvlManager : MonoBehaviour
{
    [SerializeField] private ChangeCamera changeCamera;
    [SerializeField] private MinigameTimer minigameTime;
    [SerializeField] private LvlTimer lvlTime;


    [Header("Points")]
    [SerializeField] public int satisfactionPointsGood;
    [SerializeField] public int satisfactionPointsBad;

    [Header("EndScreen")]
    [SerializeField] private GameObject[] endScreen;

    public  bool minigameIsOn;

    
    void Start()
    {
        endScreen[0].SetActive(false);
        endScreen[1].SetActive(false);
    }

    public void EndLevel()
    {
        if (satisfactionPointsGood > satisfactionPointsBad)
        {
            endScreen[0].SetActive(true);
        }

        else
        {
            endScreen[1].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMinigame()
    {
        minigameIsOn = true;
        lvlTime.PauseTimer();
        minigameTime.StartTimer();
    }

    public void EndMinigame()
    {
        minigameIsOn = false;
        minigameTime.StopTimer();
        changeCamera.ActivateCamera(0);
        lvlTime.ResumeTimer();
    }
}
