using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject ui;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }
    void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }
    public void Continue()
    {
        Toggle();
    }
    public void Retry()
    {
        Toggle();
        Launcher.ResetAtributes();
        Turret.ResetAtributes();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        Toggle();
        Launcher.ResetAtributes();
        Turret.ResetAtributes();
        SceneManager.LoadScene("Main Menu");
    }
    public void PauseButton()
    {
        Toggle();
    }
}
