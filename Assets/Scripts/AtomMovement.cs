using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomMovement : MonoBehaviour
{
    public Direction direction;
    private Vector3 initPos;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity.x == 0)
            CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (direction == Direction.Left)
            {
                rb.velocity = new Vector2(-10, 0);
                direction = Direction.Right;
            }
            else
            {
                rb.velocity = new Vector2(10, 0);
                direction = Direction.Left;
            }
        }
    }
}