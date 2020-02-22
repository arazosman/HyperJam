using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScorePanel : MonoBehaviour
{
    public Text scoreText, highScoretext;

    // Start is called before the first frame update
    void Start()
    {
        CheckHighScore();
        scoreText.text = "Score: " + ScoreManager.Instance.Score.ToString();
        highScoretext.text = "High Score: " + ScoreManager.Instance.HighScore.ToString();
    }

    private void CheckHighScore()
    {
        if (ScoreManager.Instance.Score > ScoreManager.Instance.HighScore)
        {
            ScoreManager.Instance.HighScore = ScoreManager.Instance.Score;
            PlayerPrefs.SetInt("HighScore", ScoreManager.Instance.HighScore);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
