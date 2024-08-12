using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceWithChairs : MonoBehaviour
{
    public Chair[] chairsGO;
    public Chair chair;
    public int capacity = 2;

    private void Awake()
    {
        chairsGO = new Chair[capacity];

        for (int i = 0; i < capacity; i++)
        {
            GameObject newChair = Instantiate(chair.gameObject, new Vector3(transform.position.x, transform.position.y, transform.position.z + i * 5), Quaternion.identity);
            newChair.transform.SetParent(transform);
        }

        for (int i = 0; i < capacity; i++)
        {
            chairsGO[i] = chair;
            chairsGO[i].isBusy = false;
        }
    }
    void Update()
    {


    }
}
