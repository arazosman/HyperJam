using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private Vector2 initPos;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6)
        {
            transform.position = new Vector2(initPos.x, initPos.y + Random.Range(-2, 2));

            if (Random.Range(0, 1) < 0.5f)
            {
                if (GetComponent<Obstacle>().colorType == ColorType.Red)
                {
                    GetComponent<SpriteRenderer>().color = Color.blue;
                    GetComponent<Obstacle>().colorType = ColorType.Blue;
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = Color.red;
                    GetComponent<Obstacle>().colorType = ColorType.Red;
                }
            }
        }
    }
}