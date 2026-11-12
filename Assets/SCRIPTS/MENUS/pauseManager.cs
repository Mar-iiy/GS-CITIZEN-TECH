using UnityEngine;

public class pauseManager : MonoBehaviour
{
    [SerializeField] private LvlTimer lvlTime;
    [SerializeField] GameObject pausePanel;

    public bool gamePaused;
    void Start()
    {
        pausePanel.SetActive(false);
        gamePaused = false;
    }
    public void GamePaused()
    {
        pausePanel.SetActive(true);
        lvlTime.PauseTimer();
        gamePaused = true;
    }

    public void Unpause()
    {
        pausePanel.SetActive(false);
        lvlTime.ResumeTimer();
        gamePaused = false;
    }
}
