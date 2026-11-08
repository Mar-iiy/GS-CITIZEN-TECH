using UnityEditor.Rendering;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] private Camera[] cameraScene;

    [Header("Canvas")]
    //[SerializeField] private Canvas[] canvasScene;
    [SerializeField] private Canvas canvasBorda;

    public static int activeCameraID;

    public void ActivateCamera(int cameraID)
    {
        for (int i = 0; i < cameraScene.Length; i++)
        {
            cameraScene[i].enabled = false;
        }

        /*for (int i = 0; i < canvasScene.Length; i++)
        {
            canvasScene[i].enabled = false;
        }*/

        if (cameraID >= 0 && cameraID < cameraScene.Length)
        {
            // Liga somente a câmera sorteada
            cameraScene[cameraID].enabled = true;
            activeCameraID = cameraID;
            Debug.Log("Câmera ativada: " + cameraID);
        }
        //canvasScene[SecurityScreen.intID].enabled = true;
    }
}
