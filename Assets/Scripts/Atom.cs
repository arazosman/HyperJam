using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameColors;

public class Atom : MonoBehaviour
{
    public ColorType colorType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            if (colorType == other.gameObject.GetComponent<ObstacleComponent>().colorType)
                ScoreManager.Instance.IncrementScore(100);
            else
                GameController.Instance.GameOver = true;
        }
    }
}
