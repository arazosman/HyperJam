
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject LeftBoundObject;
    public GameObject RightBoundObject;


    public GameObject normalObstaclePrefeb;


    public List<  GameObject> ObstacleList;


    public float RespawnIntervalMax = 3;
    public float RespawnIntervalMin = 1;


    public float InitialRespawnTime = 5;


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



    public int CurrentSpawnLevel = 1;

    void spawnNewObstacle()
    {
        //float x = GetLeftPos();
       // float y = GetRightPos();

       // var loc = Random.Range(x, y);
       // var vec = new Vector3(loc, transform.position.y);

        if (ObstacleList != null && ObstacleList.Count > 0)
        {

            // var scaler = Random.value * Random.value * ObstacleList.Count;



            //  int index = Random.Range(0, Mathf.Min(CurrentSpawnLevel , Mathf.CeilToInt(scaler)));
            // Mathf.Min(CurrentSpawnLevel, Mathf.CeilToInt(scaler))

            int index = Random.Range(0, ObstacleList.Count);

            var obstacle = ObstacleList[index];
  
           

            GameObject.Instantiate(obstacle);
        }
        else
        { 
            var obstacle = GameObject.Instantiate(normalObstaclePrefeb);

        }
    }
 
    // next respawn interval count
    public float nextRespawnTime;

    public float time;

    public bool started = false;

    void Start()
    {
        nextRespawnTime = InitialRespawnTime;
        time = Time.time;
        Debug.Log($"started , time is {time}");
        //time = Time.time;
    }

    // Update is called once per frame

   
    void Update()
    {
        //if (!started)
        //{
         
        //    time = Time.time;
        //    Debug.Log($"started , time is {time}");
        //    started = true;
           
        //    return;
        //}

      


        if (Time.time - time   >= nextRespawnTime)
        {
            Debug.Log("spawn time!!");

            spawnNewObstacle();

            nextRespawnTime = getNextRespawnInterval();
            time = Time.time;
        }
    }
}
