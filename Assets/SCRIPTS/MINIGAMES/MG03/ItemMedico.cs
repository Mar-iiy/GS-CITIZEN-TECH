using UnityEngine;
using System.Collections;

public class ItemMedico : MonoBehaviour
{
    private Paciente paciente;
    [SerializeField] private MinigameN03 minigameN03;

    [Header("Camera")]
    [SerializeField] Camera camera03;

    [Header("Treatment ID")]
    [SerializeField] private int tratamentoID;

    [Header("Efeitos")]
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private AudioClip audioItem;
    [SerializeField] private AudioSource audio;

    private Collider2D col;


    Vector3 startPoint;
    Vector3 startPosition;

    void Start()
    {
        col = GetComponent<Collider2D>();
        startPoint = transform.parent.position;
        startPosition = transform.position;

    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = camera03.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject == gameObject)
                continue;

            Paciente otherPaciente =
                collider.GetComponentInParent<Paciente>();

            if (otherPaciente == null)
                continue;

            if (tratamentoID == otherPaciente.pacienteID)
            {
                if (!otherPaciente.pacienteHealthy)
                {
                    Debug.Log("PACIENTE RECEBEU ATENDIMENTO");

                    otherPaciente.pacienteHealthy = true;

                    otherPaciente.CheckStatus();

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

        minigameN03.AllPatientsHealthy();
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
