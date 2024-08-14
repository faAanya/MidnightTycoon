
using System;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{


    public List<float> musicSettings;
    public bool[] levels;

    public int money, course;
    public int hearts;

    public int localisationLang;

    public List<StationState> stationWrapper;
    public List<PlaceWithChairsState> placeWithChairsWrapper;

    public List<ShopsState> shopsWrapper;

    public UpgraderState upgraderState;
    public GameData()
    {
        money = 100;
        course = 2;
        hearts = 3;
        placeWithChairsWrapper = new List<PlaceWithChairsState>();
        stationWrapper = new List<StationState>();
        shopsWrapper = new List<ShopsState>();
        upgraderState = new UpgraderState();
        upgraderState.capacityCost = 1;
        upgraderState.timeCost = 1;
        upgraderState.courseCost = 1;


    }


}
[System.Serializable]
public struct StationState
{
    public string stationNameSave;
    public float buyTimeSave;
    public bool isBoughtSave;

    public int capacitySave;
}
[System.Serializable]
public struct PlaceWithChairsState
{
    public string placeNameSave;

    public int capacitySave;
}
[System.Serializable]
public struct ShopsState
{
    public int placeNameSave;

    public int capacitySave;
}
[System.Serializable]
public struct UpgraderState
{
    public int capacityCost, timeCost, courseCost;


}