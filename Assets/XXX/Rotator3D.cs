using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator3D : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rgd;

    int dir = 1;
    void Start()
    {
        rgd = GetComponent<Rigidbody>();
        if(rgd)
            rgd.angularVelocity = Random.insideUnitSphere*10;


        dir = Random.value > 0.5 ? -1 : 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rgd)
        {
            transform.Rotate(new Vector3(0,  0, 60 * Time.deltaTime));
        }
    }
}
