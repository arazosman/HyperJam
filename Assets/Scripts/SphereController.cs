using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public GameObject LeftSphere;
    public GameObject rightSphere;

    public float Range = 2;
    public float factor = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float axis  =  Input.GetAxis("Horizontal") * factor;

        float x0  = Range * Mathf.Cos(Mathf.Deg2Rad * axis );
        float y0  = Range * Mathf.Sin(Mathf.Deg2Rad * axis );

        LeftSphere.transform.position = new Vector3(x0, LeftSphere.transform.position.y, y0);
        rightSphere.transform.position = new Vector3(y0, LeftSphere.transform.position.y, x0);
    }
}