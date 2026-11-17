using UnityEngine;
using System.Collections;

public class PipeItem : MonoBehaviour
{
    [SerializeField] private Minigame04 minigameN04;

    [Header("Camera")]
    [SerializeField] Camera camera04;

    [Header("Pipe ID")]
    [SerializeField] private int pipeItemID;

    [Header("Efeitos")]
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private AudioClip audioItem;
    [SerializeField] private AudioSource audio;

    private Collider2D col;

    Vector3 startPoint;
    Vector3 startPosition;

    bool isRepairing;

    void Start()
    {
        col = GetComponent<Collider2D>();
       
        startPoint = transform.position;
        startPosition = transform.position;

    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = camera04.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject == gameObject)
                continue;

            BrokenPipe otherBrokenPipe =
                collider.GetComponentInParent<BrokenPipe>();

            if (otherBrokenPipe == null)
                continue;

            if (pipeItemID == otherBrokenPipe.pipeId)
            {
                if (otherBrokenPipe.brokenPipe)
                {
                    Debug.Log("TUBULAÇÃO ARRUMADA");

                    otherBrokenPipe.brokenPipe = false;

                    StartCoroutine(WaitForEffects());

                }

                return;
            }
        }

        UpdatePosition(newPosition);

    }

    public void PlaySound()
    {
        audio.clip = audioItem;
        audio.Play();
    }

    private IEnumerator WaitForEffects()
    {
        particle.Play();
        PlaySound();

        yield return new WaitWhile(() => audio.isPlaying);

        yield return new WaitWhile(() => particle.IsAlive());

        minigameN04.AllPipesUnbroken();
    }

    private void OnMouseUp()
    {
        UpdatePosition(startPosition);
    }

    private void UpdatePosition(Vector3 newPosition)
    {
        transform.position = newPosition;

        Vector3 direction = newPosition - startPoint;
        transform.right = direction;
    }
}

