using UnityEngine;
using UnityEngine.SceneManagement;

public class musicManager : MonoBehaviour
{
    private ChangeCamera camera;
    
    public static musicManager Instance;

    public AudioSource audioSource;

    public AudioClip menuMusic;
    public AudioClip LevelMusic;
    public AudioClip[] minigameMusic;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(menuMusic);
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "MENU":
            case "OPTIONS":
            case "END":
                PlayMusic(menuMusic);
                break;

            case "GAME":

                ChangeMusic();

                break;
        }
    }


    public void ChangeMusic()
    {
        if (ChangeCamera.activeCameraID == 0)
        {
            PlayMusic(LevelMusic);
        }
        if (ChangeCamera.activeCameraID == 4)
        {
            PlayMusic(minigameMusic[1]);
        }
        else
        {
            PlayMusic(minigameMusic[0]);
        }
    }


    void PlayMusic(AudioClip clip)
    {
        if (audioSource.clip == clip) return;

        audioSource.clip = clip;
        audioSource.Play();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
