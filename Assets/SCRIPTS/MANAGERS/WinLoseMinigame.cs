using UnityEngine;

public class WinLoseMinigame : MonoBehaviour
{
    [SerializeField] private ChangeCamera changeCamera;
    [SerializeField] private LvlManager lvlmanager;


    [Header("EndScreen")]
    [SerializeField] private AudioClip audioItem;
    [SerializeField] private AudioSource audio;


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
        PlaySound();
        lvlmanager.satisfactionPointsB += 10;
        Return();
    }

    public void PlaySound()
    {
        audio.clip = audioItem;
        audio.Play();
    }

}
