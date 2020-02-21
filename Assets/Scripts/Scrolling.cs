using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform rocketPos;
	float initialY;
	private Vector2 initPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -5f);
        initialY = rocketPos.position.y;
		initPos = transform.position;
    }

    private void FixedUpdate()
	{
		if (transform.position.y < initialY)
			transform.position = initPos;
	}
}