using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameColors : MonoSingleton<GameColors>
{


    public enum ColorType
    {
        Red, Blue , ColorCount
    }

    private Color32 color1, color2;

    public Color32 Color1 { get => color1; set => color1 = value; }
    public Color32 Color2 { get => color2; set => color2 = value; }

    public Color32 GetColor(ColorType colorType)
    {
        return ColorList[(int)colorType];
    }

    public Dictionary<ColorType, Color> ColorDict = new Dictionary<ColorType, Color>();
    public List< Color> ColorList = new List<Color>();

 

    public ColorType RandomColorType
    {
        get
        {
            int count = ColorList.Count;
            int index = Random.Range(0, count);
            return (ColorType)index;
        }
    }


    private void Awake()
    {
        Color1 = new Color32(231, 76, 60, 255);
        Color2 = new Color32(22, 160, 133, 255);


        ColorDict.Add(ColorType.Red, Color1);
        ColorList.Add( Color1);

        ColorDict.Add(ColorType.Blue, Color2);
        ColorList.Add( Color2);
    }
}
