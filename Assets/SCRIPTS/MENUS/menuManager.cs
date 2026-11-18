using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using static UnityEngine.ParticleSystem;

public class menuManager : MonoBehaviour
{
    [SerializeField] VideoPlayer video;
    [SerializeField] GameObject BACKGROUND;
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        StartCoroutine(WaitForVideo());
    }
    public void MenuGame()
    {
        SceneManager.LoadScene(0);
    }
    public void OptionsGame()
    {
        SceneManager.LoadScene(2);
    }
    public void EndingGame()
    {
        SceneManager.LoadScene(3);
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
