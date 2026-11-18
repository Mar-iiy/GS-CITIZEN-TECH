using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class menuManager : MonoBehaviour
{
    [SerializeField] VideoPlayer video;
    [SerializeField] GameObject BACKGROUND;
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("SAIR CLICADO");
    }
    public void StartGame()
    {
        StartCoroutine(WaitForVideo());
        Debug.Log("JOGAR CLICADO");
    }
    public void MenuGame()
    {
        SceneManager.LoadScene(0);
        Debug.Log("MENU CLICADO");
    }
    public void OptionsGame()
    {
        SceneManager.LoadScene(2);
        Debug.Log("OPTIONS CLICADO");
    }
    public void EndingGame()
    {
        SceneManager.LoadScene(3);
        Debug.Log("CREDITOS CLICADO");
    }

    private IEnumerator WaitForVideo()
    {
        video.Prepare();

        yield return new WaitUntil(() => video.isPrepared);

        BACKGROUND.SetActive(false);

        video.Play();

        yield return new WaitUntil(() => !video.isPlaying && video.isPrepared);

        BACKGROUND.SetActive(true);

        SceneManager.LoadScene(1);

    }

}
