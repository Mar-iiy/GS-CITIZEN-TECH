using UnityEngine;

public class MinigameN02 : MonoBehaviour
{
    [SerializeField] private WinLoseMinigame winLose;
    [SerializeField] private LvlManager lvlManager;
    [SerializeField] private MinigameTimer minigameTimer;
    [SerializeField] private ChangeCamera changeCamera;

    private int connectedWires;

    private bool minigameWOn;

    void Update()
    {
        CheckIsOn();
    }

    void CheckIsOn()
    {
        if (!lvlManager.minigameIsOn && ChangeCamera.activeCameraID != 1)
        {
            return;
        }
    }

    public void AddConnectedWire()
    {
        connectedWires++;

        Debug.Log("Wires conectados: " + connectedWires);

        if (connectedWires >= 4)
        {
            EndMinigame();
        }
    }

    private void EndMinigame()
    {
        winLose.WinMinigame();

        connectedWires = 0;

        Wire[] wires = FindObjectsByType<Wire>();

        foreach (Wire wire in wires)
        {
            wire.ResetWire();
        }

    }
}
