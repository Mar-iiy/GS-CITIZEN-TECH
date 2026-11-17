using UnityEngine;

public class manualManager : MonoBehaviour
{
    [SerializeField] GameObject manualPanel;

    void Start()
    {
        manualPanel.SetActive(false);
    }
    public void ManualOn()
    {
        manualPanel.SetActive(true);
    }

    public void ManualOff()
    {
        manualPanel.SetActive(false);
    }
}
