using UnityEngine;
using static UnityEngine.Audio.ProcessorInstance;

public class Minigame04 : MonoBehaviour
{

    [SerializeField] private WinLoseMinigame winLose;
    [SerializeField] private LvlManager lvlManager;
    [SerializeField] private ChangeCamera changeCamera;

    [SerializeField] GameObject[] pipes;


    private bool pipesRandomized = false;

    private void Update()
    {
        CheckIsOn();
    }

    private void RandomizePipes()
    {
        foreach (GameObject obj in pipes)
        {
            BrokenPipe pipe = obj.GetComponent<BrokenPipe>();

            if (pipe != null)
            {
                pipe.IsBroken();
            }
        }
    }

    private void CheckIsOn()
    {
        if (!lvlManager.minigameIsOn || ChangeCamera.activeCameraID != 4)
        {
            pipesRandomized = false;
            return;
           
        }

        if (!pipesRandomized)
        {
            RandomizePipes();
            pipesRandomized = true;
        }

            int brokenCount = 0;

            foreach (GameObject obj in pipes)
            {
                BrokenPipe pipe = obj.GetComponent<BrokenPipe>();

                if (pipe != null && pipe.brokenPipe)
                {
                    brokenCount++;
                }
            }

            if (brokenCount == 0)
            {
                EndMinigame();
            }
    }

    public void AllPipesUnbroken()
    {
        foreach (GameObject obj in pipes)
        {
            BrokenPipe pipe = obj.GetComponent<BrokenPipe>();

            if (pipe == null || pipe.brokenPipe)
            {
                return;
            }
        }

        EndMinigame();
    }

    private void EndMinigame()
    {
        winLose.WinMinigame();
    }
}

