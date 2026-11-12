using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{ 
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OptionsMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuGame()
    {
        SceneManager.LoadScene(0);
    }

}
