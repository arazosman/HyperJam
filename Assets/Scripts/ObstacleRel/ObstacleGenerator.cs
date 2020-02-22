using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject LeftBoundObject;
    public GameObject RightBoundObject;


    public GameObject normalObstaclePrefeb;


    public float RespawnIntervalMax = 3;
    public float RespawnIntervalMin = 1;


    public float InitialRespawnTime = 5;




    float getLeftPos() => LeftBoundObject?.transform.position.x ?? 0;
    float getRightPos() => RightBoundObject?.transform.position.x ?? 5;


    float getNextRespawnInterval() => Random.Range(RespawnIntervalMin, RespawnIntervalMax);
    void spawnNewObstacle()
    {
        float x = getLeftPos();
        float y = getRightPos();

        var loc = Random.Range(x, y);


        var vec = new Vector3(loc, transform.position.y);
        var obstacle = GameObject.Instantiate(normalObstaclePrefeb , vec, Quaternion.identity);
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
