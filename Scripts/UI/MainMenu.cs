using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Select Level");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
