using UnityEngine;

public class lostItem : MonoBehaviour
{
    [SerializeField] private WinLoseMinigame winLose;
    [SerializeField] private MinigameN01 minigame01;

    private Collider2D col;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        Debug.Log("OBJETO CLICADO");
        winLose.WinMinigame();
        minigame01.EndMinigame();
    }
}
