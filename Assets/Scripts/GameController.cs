using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoSingleton<GameController>
{

    public SpinController spinController;


    public ScrollerStatic nebula;
    public ScrollerStatic bigStars;
    public ScrollerStatic littleStars;

    public UnityStandardAssets.CinematicEffects.Bloom Bloom;



    public Slider PowerUpBar;



    private bool powerupEnabled = false;

    public float extendPowerUpDuration = 0;

    private int powerupCount = 0;
    public  int powerupNeedCount = 5;



    public GameObject gameOverPanel;
    private bool gameOver = false;


    float currentPowerUpDuration = 0;

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

        if (powerupEnabled)
        {
            currentPowerUpDuration -= Time.deltaTime;

            if (currentPowerUpDuration <= 0)
            {
                powerupEnabled = false;
                PowerUpBar.value = 0;

                Bloom.settings.intensity = initialBloom;


               PowerupCount = 0;
                SpinController.Instance.EnableLightning(false);

            }
            else
            {
                PowerUpBar.value = currentPowerUpDuration / powerupduration;
                Debug.Log($" val {PowerUpBar.value}");
            }

        }
        else
        {
            PowerUpBar.value = (float)PowerupCount / (float)powerupNeedCount;
        }
    }

    public bool GameOver { get => gameOver; set => gameOver = value; }
    public bool PowerupEnabled { get => powerupEnabled; set {

 
            powerupEnabled = value;
                
                } }
    public int PowerupCount { get => powerupCount; set
        {
            PowerUpBar.value = value;
            powerupCount = value;

        }
    }


    public float powerupduration = 10;


    private float initialBloom;


    float remainSecs = 0;
    public float PowerUpRemainSecs { get {

            return remainSecs;
        }
        set
        {
            remainSecs = value;
        } 
    }

    public void OnPowerUp(GameObject gameObject1, GameObject gameObject2)
    {
        if (PowerupEnabled)
        {
            //extendPowerUpDuration += powerupduration;
            currentPowerUpDuration += powerupduration / powerupNeedCount;

        }
        else
        {
            PowerupCount++;
            if (PowerupCount >= powerupNeedCount)
            {

                initialBloom = Bloom.settings.intensity;

                Bloom.settings.intensity = initialBloom * 2;

               PowerupEnabled = true;

                //initialCameraBloomIntecity

                SpinController.Instance.EnableLightning(true);
                currentPowerUpDuration = powerupduration;
 
                //StartCoroutine("DisablePowerUp");
            }
        }

    }

    public IEnumerator DisablePowerUp()
    {
        yield return new WaitForSeconds(GameController.Instance.powerupduration);

        var gc = GameController.Instance;

        while (gc.extendPowerUpDuration != 0)
        {
            gc.extendPowerUpDuration = 0;
            yield return new WaitForSeconds(gc.extendPowerUpDuration);
        }

        GameController.Instance.PowerupCount = 0;
        SpinController.Instance.EnableLightning(false);

        GameController.Instance.PowerupEnabled = false;

        GameController.Instance.PowerUpRemainSecs = 0.0f;
    }
}