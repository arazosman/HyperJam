using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleStick: Obstacle
{

    public override void UpdateLocation()
    {
        if (autoAssignLocation)
        {
            var instance = ObstacleGenerator.Instance;

            float left = instance.GetLeftPos();
            float right = instance.GetRightPos();
            float y = instance.GetCurrentY();
            float z = instance.GetCurrentZ();

            if (Random.value < 0.33)
            {
                this.transform.position = new Vector3(left, y, z);
            }
            else if (Random.value < 0.66)
            {
                this.transform.position = new Vector3(right, y, z);
            }
            else
            {
                this.transform.position = new Vector3( (left+ right)/2, y, z);
            }
           
        }
        else
        {


        }
    }
}
