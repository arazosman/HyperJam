

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject LeftBoundObject;
    public GameObject RightBoundObject;

    public List<  GameObject> ObstacleList;


    public float RespawnIntervalMax = 3;
    public float RespawnIntervalMin = 1;

    public float InitialRespawnTime = 5;

    // next respawn interval count
    public float nextRespawnTime;

    public float respawnTimer;

    public List<GameObject> PowerUpList;

    public float PowerUpIntervalMax = 15;
    public float PowerUpIntervalMin = 10;

    public float InitialPowerUpTime = 10;

    public float powerUpTimer;

    public float nextPowerUpTime;


    public static ObstacleGenerator Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public float GetCurrentZ()
    {
        return  transform.position.z;
    }
    public float GetLeftPos() => LeftBoundObject?.transform.position.x ?? 0;
    public float GetRightPos() => RightBoundObject?.transform.position.x ?? 5;
    public float GetCurrentY() => transform.position.y;


    float getNextRespawnInterval() => Random.Range(RespawnIntervalMin, RespawnIntervalMax);
    float getNextPowerUpInterval() => Random.Range(PowerUpIntervalMin, PowerUpIntervalMax);


    public int CurrentSpawnLevel = 1;

    void spawnNewObstacle()
    {
        if (ObstacleList != null && ObstacleList.Count > 0)
        {
            int index = Random.Range(0, ObstacleList.Count);

            var obstacle = ObstacleList[index];

            GameObject.Instantiate(obstacle);
        }
    }
 




    public bool started = false;

    void Start()
    {
        nextRespawnTime = InitialRespawnTime;
        nextPowerUpTime = InitialPowerUpTime;
        respawnTimer = Time.time;
        powerUpTimer = respawnTimer;
    }

    void Update()
    {
        if (Time.time - respawnTimer   >= nextRespawnTime)
        {
            Debug.Log("spawn time!!");

            spawnNewObstacle();

            nextRespawnTime = getNextRespawnInterval();
            respawnTimer = Time.time;
        }

        if (Time.time - powerUpTimer >= nextPowerUpTime)
        {
            Debug.Log("Powerup time!!");

            spawnNewPowerUp();

            nextPowerUpTime = getNextPowerUpInterval();
            powerUpTimer = Time.time;
        }

    }

    private void spawnNewPowerUp()
    {
        if (PowerUpList != null && PowerUpList.Count > 0)
        {
            int index = Random.Range(0, PowerUpList.Count);

            var obstacle = PowerUpList[index];

            GameObject.Instantiate(obstacle);
        }
    }
}
