using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotator : Obstacle
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



            if (Random.value < 0.5)
            {
                this.transform.position = new Vector3(left, y, z);
            }
            else 
            {
                this.transform.position = new Vector3(right, y, z);
            }
            

        }
        else
        {


        }
    }
}
