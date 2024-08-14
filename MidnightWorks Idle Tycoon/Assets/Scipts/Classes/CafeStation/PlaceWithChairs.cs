using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceWithChairs : MonoBehaviour, IDataPersistence
{

    public List<GameObject> chairsGO;
    public Chair chair;
    public int capacity;
    public int maxCapacity = 4;

    public void LoadData(GameData gameData)
    {
        foreach (var item in gameData.placeWithChairsWrapper)
        {
            if (item.placeNameSave == gameObject.name)
            {
                capacity = item.capacitySave;
                break;
            }
        }
    }

    public void SaveData(ref GameData gameData)
    {


        PlaceWithChairsState stationState = new PlaceWithChairsState();
        stationState.capacitySave = capacity;
        stationState.placeNameSave = gameObject.name;
        gameData.placeWithChairsWrapper.Add(stationState);

    }


    private void Start()
    {
        Debug.Log("I birth");
        chairsGO = new List<GameObject>(capacity);
        for (int i = 0, j = 0; i < capacity && j < 360; i++, j += 360 / capacity)
        {
            Vector3 pos = new Vector3(.5f * Mathf.Cos(j * Mathf.PI / 180) + transform.position.x, transform.position.y, .5f * Mathf.Sin(j * Mathf.PI / 180) + transform.position.z);
            GameObject newChair = Instantiate(chair.gameObject, pos, Quaternion.Euler(0, (j + 180f) * Mathf.Pow(-1, i), 0));
            chairsGO.Add(newChair);
            chairsGO[i].GetComponent<Chair>().isBusy = false;

            newChair.transform.SetParent(gameObject.transform);
        }



    }


}
