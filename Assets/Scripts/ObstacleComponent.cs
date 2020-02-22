 
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
        if (autoAssignRandomColor)
        {
            colorType = GameColors.Instance.RandomColorType;
            SetGameColor(colorType);

        }
        else
        {
            SetGameColor(colorType);
        }
          
        
      

    }

 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameColor(ColorType colorType)
    {
   
        GetComponent<SpriteRenderer>().color = GameColors.Instance.ColorList[(int)colorType];
    }
}
