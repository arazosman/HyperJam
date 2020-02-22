using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject LeftAtom;
    public GameObject RightAtom;

    public float MinRange = 1;

    void Start()
    {
        Physics2D.IgnoreCollision(LeftAtom.GetComponent<Collider2D>() , RightAtom.GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float range = Mathf.Abs(LeftAtom.transform.position.x - RightAtom.transform.position.x);

        if (range < MinRange)
        {
            float dist  = (1.0f - range/MinRange);

            var leftc = Color.Lerp(Color.red, Color.magenta, dist);
            var rightc = Color.Lerp(Color.blue, Color.magenta, dist);

            LeftAtom.GetComponent<SpriteRenderer>().color = leftc;
            RightAtom.GetComponent<SpriteRenderer>().color = rightc;

            if (range < 0.25)
            {
                float newX = (LeftAtom.transform.position.x + RightAtom.transform.position.x) / 2f;
                LeftAtom.transform.position = new Vector2(newX, LeftAtom.transform.position.y);
                RightAtom.transform.position = new Vector2(newX, RightAtom.transform.position.y);
                LeftAtom.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                RightAtom.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
        }
    }
}