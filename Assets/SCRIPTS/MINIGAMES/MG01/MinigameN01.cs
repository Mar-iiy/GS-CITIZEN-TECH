using UnityEngine;

public class MinigameN01 : MonoBehaviour
{
    [SerializeField] private WinLoseMinigame winLose;
    [SerializeField] private LvlManager lvlManager;
    [SerializeField] private MinigameTimer minigameTimer;
    [SerializeField] private ChangeCamera changeCamera;

    [Header("Object")]
    [SerializeField] private GameObject lostItemPrefab;

    [Header("Object Spawn Settings")]
    [SerializeField] private float minX = -4f;
    [SerializeField] private float maxX = 4f;
    [SerializeField] private float minY = -4f;
    [SerializeField] private float maxY = 4f;

    [SerializeField] private GameObject currentItem;
    private bool itemSpawned = false;
    private int minigameCamera;

    void Update()
    {
        CheckIsOn();
        EndMinigame();
    }

    void CheckIsOn()
    {   
        if (!lvlManager.minigameIsOn && ChangeCamera.activeCameraID != 1)
        {  
            return; 
        }

        if(!itemSpawned && ChangeCamera.activeCameraID == 1)
        {
            PlayMinigame();
        }
    }

    void PlayMinigame()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        float randomRotation = Random.Range(0f, 360f);
        currentItem = Instantiate(lostItemPrefab, randomPosition, Quaternion.Euler(0f, 0f, randomRotation));

        SpriteRenderer sr = currentItem.GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            sr.color = new Color(Random.value, Random.value, Random.value);
        }

        itemSpawned = true;
    }

    public void EndMinigame()
    {
        if (minigameTimer.currentTime <= 0)
        {
            if (currentItem != null)
            {
                Destroy(currentItem);
            }

            currentItem = null;
            itemSpawned = false;
        }

        else return;
    }
}
