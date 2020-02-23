using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public Image soundLine, vibrationLine;

    private void OnEnable()
    {
        soundLine.enabled = !Settings.Instance.Sound;
        vibrationLine.enabled = !Settings.Instance.Vibration;
    }

    public void ContinueButton()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void SoundButton()
    {
        Settings.Instance.Sound = !Settings.Instance.Sound;
        soundLine.enabled = !Settings.Instance.Sound;
        PlayerPrefs.SetInt("Settings", Settings.Instance.Sound ? 1 : 0);
        MusicManager.Instance.SetSounds(Settings.Instance.Sound ? 1 : 0);
    }

    public void VibrationButton()
    {
        Settings.Instance.Vibration = !Settings.Instance.Vibration;
        vibrationLine.enabled = !Settings.Instance.Vibration;
        PlayerPrefs.SetInt("Vibration", Settings.Instance.Vibration ? 1 : 0);
    }

    public void ReplayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
