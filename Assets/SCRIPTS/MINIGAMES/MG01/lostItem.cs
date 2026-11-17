using UnityEngine;
using System.Collections;
public class lostItem : MonoBehaviour
{
    [SerializeField] private WinLoseMinigame winLose;
    [SerializeField] private MinigameN01 minigame01;

    [Header("Efeitos")]
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private AudioClip audioItem;
    [SerializeField] private AudioSource audio;

    private Collider2D col;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    public void PlaySound()
    {
            audio.clip = audioItem;
            audio.Play();
    }

    private void OnMouseDown()
    {
        Debug.Log("OBJETO CLICADO");

        particle.Play();
        PlaySound();

        StartCoroutine(WaitForEffects());
    }

    private IEnumerator WaitForEffects()
    {
        particle.Play();
        PlaySound();

        yield return new WaitWhile(() => audio.isPlaying);

        yield return new WaitWhile(() => particle.IsAlive());

        winLose.WinMinigame();
        minigame01.EndMinigame();
    }
}
