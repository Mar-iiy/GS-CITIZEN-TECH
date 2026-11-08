using UnityEngine;

public class MinigameN01 : MonoBehaviour
{
    [SerializeField] private WinLoseMinigame winLose;
    private Collider2D col;

    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        Debug.Log("OBJETO CLICADO");
        winLose.WinMinigame();
    }
}
