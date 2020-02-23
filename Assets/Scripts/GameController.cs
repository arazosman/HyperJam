using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoSingleton<GameController>
{

    public SpinController spinController;


    public ScrollerStatic nebula;
    public ScrollerStatic bigStars;
    public ScrollerStatic littleStars;



 



    public GameObject gameOverPanel;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(Wait(1));
    }

    public float GetVerticalSpeedFactor
    {
        get => spinController.VerticalSpeedFactor;
    }

    public int levelFactor = 10;
    public IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);


        Debug.Log($"evet....{levelFactor}");
        var vel =  Mathf.Log( levelFactor * 10);


        spinController.VerticalSpeedFactor += vel;

        nebula.speed += vel;
        bigStars.speed += vel;
        littleStars.speed += vel;

        levelFactor++;

        StartCoroutine(Wait(10));
    }

    void Update()
    {
        if (gameOver)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public bool GameOver { get => gameOver; set => gameOver = value; }
}