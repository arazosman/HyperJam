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
        else
            CheckEdges();
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (direction == Direction.Right)
                rb.velocity = new Vector2(10, 0);
            else
                rb.velocity = new Vector2(-10, 0);

            direction = direction == Direction.Left ? Direction.Right : Direction.Left;
        }
    }

    private void CheckEdges()
    {
        if (transform.position == initPos)
            rb.velocity = Vector2.zero;
    }
}