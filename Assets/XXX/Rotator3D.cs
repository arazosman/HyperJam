using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator3D : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rgd;
    void Start()
    {
        rgd = GetComponent<Rigidbody>();
        if(rgd)
            rgd.angularVelocity = Random.insideUnitSphere*10;
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
