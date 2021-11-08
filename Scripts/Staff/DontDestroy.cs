using UnityEngine.SceneManagement;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public AudioSource menuMusic;
    public AudioSource levelsMusic;
    private void Awake()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("Music");
        if (music.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.buildIndex == 0 || scene.buildIndex == 1 || scene.buildIndex == 7)
        {
            StopMusic(levelsMusic);
            PlayMusic(menuMusic);
        }
        else
        {
            StopMusic(menuMusic);
            PlayMusic(levelsMusic);
        }
    }
    public void PlayMusic(AudioSource source)
    {
        if (source.isPlaying)
            return;
        source.Play();
    }
    public void StopMusic(AudioSource source)
    {
        source.Stop();
    }
}
