using UnityEngine;

public class ItemMedico : MonoBehaviour
{
    private Paciente paciente;
    [SerializeField] private MinigameN03 minigameN03;

    [Header("Camera")]
    [SerializeField] Camera camera03;

    [Header("Treatment ID")]
    [SerializeField] private int tratamentoID;

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

                        minigameN03.AllPatientsHealthy();
                    }

                    return;
            }
        }

        UpdatePosition(newPosition);
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
