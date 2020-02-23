using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorZ : MonoBehaviour
{
    Rigidbody rgd;

    int dir = 1;


    void Start()
    {
        rgd = GetComponent<Rigidbody>();
        if (rgd)
            rgd.angularVelocity = Random.insideUnitSphere * 10;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!rgd)
        {
            transform.Rotate(new Vector3(0, 60 * Time.deltaTime, 0));
        }
    }
}
