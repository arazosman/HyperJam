using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator3D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var rgd = GetComponent<Rigidbody>();

        rgd.angularVelocity = Random.insideUnitSphere*10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
