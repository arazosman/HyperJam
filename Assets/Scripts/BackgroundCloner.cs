using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCloner : MonoBehaviour
{
    public Transform atomPos;
	private float initialY;
	private Vector2 initPos;

    private void Start()
    {
        initialY = atomPos.position.y;
		initPos = transform.position;
    }

    private void FixedUpdate()
	{
		if (transform.position.y + 5f < initialY)
			transform.position = initPos;
	}
}