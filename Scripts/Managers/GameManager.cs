using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    public static bool levelCleared;

    public GameObject gameOverUI;
    public GameObject levelClearedUI;

    public int nextLevelToUnlock;

    private void Start()
    {
        isGameOver = false;
        levelCleared = false;
    }
    void Update()
    {
        if (isGameOver)
            return;
        if (levelCleared)
        {
            levelClearedUI.SetActive(true);
        }
        if (PlayerStats.Lives <= 0)
        {
            GameEnd();
        }
    }
    void GameEnd()
    {
        Launcher.ResetAtributes();
        Turret.ResetAtributes();
        isGameOver = true;
        gameOverUI.SetActive(true);
    }
    public void LevelCleared()
    {
        Launcher.ResetAtributes();
        Turret.ResetAtributes();
        levelCleared = true;
        PlayerPrefs.SetInt("levelReached", nextLevelToUnlock);
    }
}
