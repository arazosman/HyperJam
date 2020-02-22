using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoSingleton<ScoreManager>
{
    public Text scoreText;
    private int score = 0;
    private int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
            HighScore = PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore(int add)
    {
        score += add;
        scoreText.text = score.ToString();
    }

    public int Score { get => score; }
    public int HighScore { get => highScore; set => highScore = value; }
}