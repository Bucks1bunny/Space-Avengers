using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCleared : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
