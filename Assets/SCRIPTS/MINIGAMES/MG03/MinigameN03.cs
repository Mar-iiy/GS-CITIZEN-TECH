using UnityEngine;

public class MinigameN03 : MonoBehaviour
{
    [SerializeField] private WinLoseMinigame winLose;
    [SerializeField] private LvlManager lvlManager;
    private Paciente paciente;
    [SerializeField] private ChangeCamera changeCamera;

    [SerializeField] GameObject[] pacientes;

    private bool pacientesSorteados;

    private void Update()
    {
        CheckIsOn();
    }

    private void CheckIsOn()
    {
        if (!lvlManager.minigameIsOn ||
            ChangeCamera.activeCameraID != 3)
        {
            return;
        }

        if (!pacientesSorteados)
        {
            foreach (GameObject obj in pacientes)
            {
                Paciente paciente = obj.GetComponent<Paciente>();

                if (paciente != null)
                {
                    paciente.SortPaciente();
                }
            }

            pacientesSorteados = true;
        }
    }

    public void AllPatientsHealthy()
    {
        foreach (GameObject obj in pacientes)
        {
            Paciente paciente = obj.GetComponent<Paciente>();

            if (paciente == null || !paciente.pacienteHealthy)
            {
                return;
            }
        }

        EndMinigame();
    }

    private void EndMinigame()
    {
        winLose.WinMinigame();

        foreach (GameObject obj in pacientes)
        {
            Paciente paciente = obj.GetComponent<Paciente>();

            if (paciente != null)
            {
                paciente.ChangePaciente(0);
                paciente.pacienteID = 0;
                paciente.pacienteHealthy = false;
            }
        }

        pacientesSorteados = false;
    }
}
