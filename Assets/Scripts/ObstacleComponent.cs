 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameColors;

public class ObstacleComponent : MonoBehaviour
{
    public ColorType colorType;

    public bool autoAssignRandomColor = true;

    // Start is called before the first frame update
    void Start()
    {
        if(autoAssignRandomColor)
            SetGameColor( GameColors.Instance.RandomColorType);
        else
            SetGameColor(colorType);

    }

 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameColor(ColorType colorType)
    {
        colorType = colorType;
        GetComponent<SpriteRenderer>().color = GameColors.Instance.ColorList[(int)colorType];
    }
}
