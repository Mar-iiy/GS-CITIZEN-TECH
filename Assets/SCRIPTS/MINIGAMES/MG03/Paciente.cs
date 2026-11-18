using UnityEngine;

public class Paciente : MonoBehaviour
{
    public int pacienteID;
    public bool pacienteHealthy;

    [SerializeField] SpriteRenderer sr;
    [SerializeField] Sprite[] pacienteSprite;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SortPaciente()
    {
        pacienteID = Random.Range(0, 3);
        ChangePaciente(pacienteID);
        pacienteHealthy = false;
    }

    public void CheckStatus()
    {

        if (pacienteHealthy)
        {
            Debug.Log("PACIENTE SAUDAVEL");
        }
    }

    public void ChangePaciente(int id)
    {
        if (id >= 0 && id < pacienteSprite.Length)
        {
            sr.sprite = pacienteSprite[id];
        }
    }
}
