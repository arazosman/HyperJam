 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameColors;

public class AutoObstacle : MonoBehaviour
{
    public ColorType colorType;

    // Start is called before the first frame update
    void Start()
    {

        SetColorType(Random.value > 0.5 ? ColorType.Blue : ColorType.Red);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColorType(ColorType colorType)
    {
        

        this.colorType = colorType;

        switch (colorType)
        {
            case ColorType.Red:
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case ColorType.Blue:
                GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            default:
                break;
        }
    }
}
