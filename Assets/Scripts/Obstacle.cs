 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public bool autoAssignLocation   = true;

    // Start is called before the first frame update
    void Start()
    {
        UpdateLocation();
    }


    public virtual void UpdateLocation()
    {
        if (autoAssignLocation)
        {
            var instance = ObstacleGenerator.Instance;
            float left = instance.GetLeftPos();
            float right = instance.GetRightPos();
            float y = instance.GetCurrentY();
            float z = instance.GetCurrentZ();

            var randX = Random.Range(left, right);
            this.transform.position = new Vector3(randX, y, z);
        }
        else
        {


        }
    }

 
    void Update()
    {
        
    }
 
}
