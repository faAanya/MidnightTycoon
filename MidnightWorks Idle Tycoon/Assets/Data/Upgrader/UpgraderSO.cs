using UnityEngine;

[System.Serializable]
public class UpgraderSO : MonoBehaviour, IDataPersistence
{
    public int capacityCost, timeCost, courseCost;

    public void LoadData(GameData gameData)
    {
        capacityCost = gameData.upgraderState.capacityCost;
        timeCost = gameData.upgraderState.timeCost;
        courseCost = gameData.upgraderState.courseCost;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.upgraderState.capacityCost = capacityCost;
        gameData.upgraderState.timeCost = timeCost;
        gameData.upgraderState.courseCost = courseCost;
    }
}