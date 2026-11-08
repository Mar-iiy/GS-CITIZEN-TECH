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
        lvlmanager.satisfactionPointsGood += 10;
        Return();
    }
    public void LoseMinigame()
    {
        lvlmanager.satisfactionPointsBad += 10;
        Return();
    }

}
