using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceWithChairs : MonoBehaviour
{

    public List<GameObject> chairsGO;
    public Chair chair;
    public int capacity = 0;
    public int maxCapacity = 4;
    private void Awake()
    {
        chairsGO = new List<GameObject>(capacity);
        for (int i = 0, j = 0; i < capacity && j < 360; i++, j += 360 / capacity)
        {
            Vector3 pos = new Vector3(3 * Mathf.Cos(j * Mathf.PI / 180) + transform.position.x, transform.position.y, 3 * Mathf.Sin(j * Mathf.PI / 180) + transform.position.z);
            GameObject newChair = Instantiate(chair.gameObject, pos, Quaternion.Euler(0, (j + 180f) * Mathf.Pow(-1, i), 0));
            chairsGO.Add(newChair);
            chairsGO[i].GetComponent<Chair>().isBusy = false;

            newChair.transform.SetParent(gameObject.transform);
        }



    }

    public void BuildChairs()
    {

        for (int i = 0, j = 0; i < capacity && j < 360; i++, j += 360 / capacity)
        {
            Vector3 pos = new Vector3(3 * Mathf.Cos(j * Mathf.PI / 180) + transform.position.x, transform.position.y, 3 * Mathf.Sin(j * Mathf.PI / 180) + transform.position.z);
            chairsGO[i].transform.position = pos;
            chairsGO[i].transform.rotation = Quaternion.Euler(0, (j + 180f) * Mathf.Pow(-1, i), 0);

            chairsGO[i].transform.SetParent(gameObject.transform);
        }
    }

    public void DestroyChairs()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
    }

}
