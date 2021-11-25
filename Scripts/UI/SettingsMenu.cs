using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
    public void BackButton()
    {
        SceneManager.LoadScene("Main menu");
    }
}
