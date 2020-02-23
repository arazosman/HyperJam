using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private Button playButton,soundButton, vibrationButton, exitButton;
    [SerializeField]
    private Image soundLine, vibrationLine;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Settings"))
        {
            Settings.Instance.Sound = PlayerPrefs.GetInt("Settings") == 1;
            soundLine.enabled = PlayerPrefs.GetInt("Settings") == 0;

        }

        if (PlayerPrefs.HasKey("Vibration"))
        {
            Settings.Instance.Vibration = PlayerPrefs.GetInt("Vibration") == 1;
            vibrationLine.enabled = PlayerPrefs.GetInt("Vibration") == 0;
        }

        /*
        // Ternary operator
        Settings.Instance.Sound = PlayerPrefs.HasKey("Settings") ? PlayerPrefs.GetInt("Settings") == 1 : true;
        Settings.Instance.Vibration = PlayerPrefs.HasKey("Vibration") ? PlayerPrefs.GetInt("Vibration") == 1 : true;
        */
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Gameplay");
    }
    
    public void SoundButton()
    {
        Settings.Instance.Sound = !Settings.Instance.Sound;
        soundLine.enabled = !Settings.Instance.Sound;
        PlayerPrefs.SetInt("Settings", Settings.Instance.Sound ? 1 : 0);
    }

    public void VibrationButton()
    {
        Settings.Instance.Vibration = !Settings.Instance.Vibration;
        vibrationLine.enabled = !Settings.Instance.Vibration;
        PlayerPrefs.SetInt("Vibration", Settings.Instance.Vibration ? 1 : 0);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
