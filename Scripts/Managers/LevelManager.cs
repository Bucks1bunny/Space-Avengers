using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Button[] buttons;

    public Color closedColor;
    
    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);  

        for (int i = 0; i < buttons.Length; i++)
        {
            if(i+1 > levelReached)
            {
                buttons[i].interactable = false;
                buttons[i].GetComponent<Graphic>().color = Color.grey;
            }
        }
    }
    #region Levels
    public void FirstLevel()
    {
        LoadLevel(0);
    }
    public void SecondLevel()
    {
        LoadLevel(1);
    }
    public void ThirdLevel()
    {
        LoadLevel(2);
    }
    public void FourthLevel()
    {
        LoadLevel(3);
    }
    public void FifthLevel()
    {
        LoadLevel(4);
    }
    #endregion
    public void LoadLevel(int levelIndex)
    {
        if (buttons[levelIndex].interactable == true)
        {
            SceneManager.LoadScene(levelIndex+2);
        }
    }
    public void GoBack()
    {
        SceneManager.LoadScene("Main menu");
    }
}
