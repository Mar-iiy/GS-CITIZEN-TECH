using System.Security.Cryptography;
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SortPaciente()
    {
        pacienteID = Random.Range(1, 4);
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
