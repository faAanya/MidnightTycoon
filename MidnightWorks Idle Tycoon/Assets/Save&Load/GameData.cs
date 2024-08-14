
using System;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{


    public List<float> musicSettings;
    public bool[] levels;

    public float money, course;
    public int hearts;

    public int localisationLang;

    public List<StationState> stationWrapper;
    public List<PlaceWithChairsState> placeWithChairsWrapper;


    public GameData()
    {
        placeWithChairsWrapper = new List<PlaceWithChairsState>();
        stationWrapper = new List<StationState>();
        money = 5;
        course = 2;
        hearts = 3;
    }


}
[System.Serializable]
public struct StationState
{
    public string stationNameSave;
    public float buyTimeSave;

    public int capacitySave;
}
[System.Serializable]
public struct PlaceWithChairsState
{
    public string placeNameSave;

    public int capacitySave;
}