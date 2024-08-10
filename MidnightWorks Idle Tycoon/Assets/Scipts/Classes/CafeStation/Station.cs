using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    public Timer[] queue;
    public float buyTime;

    public int capacity;

    void Start()
    {
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
}

public class Timer
{
    public Timer(float timer, bool busy)
    {
        buyTime = timer;
        isBusy = busy;
        Debug.Log("I exist");
    }
    public float buyTime;
    public bool isBusy;
}