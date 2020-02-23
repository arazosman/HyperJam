using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        var obs =  col.gameObject.GetComponentInParent<Obstacle>();

        GameObject.Destroy(obs.gameObject);
        //Debug.Log($"bunu destroy edicem {obs.gameObject}");
        //GameObject.Destroy(col.otherCollider.gameObject);


    }


}
