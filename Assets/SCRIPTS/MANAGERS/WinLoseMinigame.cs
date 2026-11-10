using UnityEngine;

public class WinLoseMinigame : MonoBehaviour
{
    [SerializeField] private ChangeCamera changeCamera;
    [SerializeField] private LvlManager lvlmanager;

    public void Return()
    {
        lvlmanager.EndMinigame();
    }

    public void WinMinigame()
    {
        lvlmanager.satisfactionPointsG += 10;
        Return();
    }
    public void LoseMinigame()
    {
        lvlmanager.satisfactionPointsB += 10;
        Return();
    }

}
