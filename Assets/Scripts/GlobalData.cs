using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GlobalData
{
    public static int Score {  get; set; }
    public static int BrickRows { get; set; } = 4;
    public static int BrickHP { get; set; } = 3;

    public static int IncreaseScore(int amount)
    {
        return Score++;
    }

    public static void SetRowsHp(Slider s)
    {
        if (s.name == "RowsSlider") s.value = BrickRows;
        else if (s.name == "BrickHPSlider") s.value = BrickHP;
    }
}
