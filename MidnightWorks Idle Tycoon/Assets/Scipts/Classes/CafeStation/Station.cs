using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class Station : MonoBehaviour, IDataPersistence
{
    public Timer[] queue;
    public float buyTime;

    public int capacity;

    public bool isBought = true;

    public GameObject stationUI, allComponents, buyUI;

    public void Start()
    {
        if (!isBought)
        {
            allComponents.SetActive(false);

            GetComponent<PlayerInput>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;


        }
        else
        {

            GetComponent<PlayerInput>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
            allComponents.SetActive(true);
            Destroy(buyUI.gameObject);
        }
        queue = new Timer[capacity];
        SetTimers();
    }

    void SetTimers()
    {
        for (int i = 0; i < capacity; i++)
        {
            queue[i] = new Timer(buyTime, false);
        }
    }

    public void StartTimer(int index)
    {
        queue[index].buyTime -= Time.deltaTime;
        Debug.Log($"You startes timer № {index}");
    }

    public void ResetTimer(int index)
    {
        queue[index] = new Timer(buyTime, false);
    }

    public void LoadData(GameData gameData)
    {
        foreach (var item in gameData.stationWrapper)
        {
            if (item.stationNameSave == gameObject.name)
            {
                buyTime = item.buyTimeSave;
                capacity = item.capacitySave;
                isBought = item.isBoughtSave;
                break;
            }
        }

    }

    public void SaveData(ref GameData gameData)
    {

        StationState stationState = new StationState();
        stationState.buyTimeSave = buyTime;
        stationState.capacitySave = capacity;
        stationState.isBoughtSave = isBought;
        stationState.stationNameSave = gameObject.name;
        gameData.stationWrapper.Add(stationState);


    }

}

public class Timer
{
    public Timer(float timer, bool busy)
    {
        buyTime = timer;
        isBusy = busy;
    }
    public float buyTime;
    public bool isBusy;
}