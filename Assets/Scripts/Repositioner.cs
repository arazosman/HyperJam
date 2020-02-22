using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repositioner : MonoBehaviour
{
    public Transform referancePos;
    private Vector2 initPos;
    private float initialY;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        initialY = referancePos.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y + 10f < initialY)
			transform.position = initPos;
    }
}