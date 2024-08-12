
using System;
using System.Collections.Generic;


[System.Serializable]
public class GameData
{


    public List<float> musicSettings;
    public bool[] levels;

    public float money, course;
    public int hearts;

    public int localisationLang;

    public GameData()
    {
        money = 5;
        course = 2;
        hearts = 3;
    }
}
