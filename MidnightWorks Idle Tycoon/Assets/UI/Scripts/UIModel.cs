using System;
using UnityEngine;
public class UIModel
{
    public event Action<int> OnMoneyChanged, OnCourseChanged;
    public event Action<int> OnHeartsChanged;
    private int currentMoney, currentCourse;
    private int currentHearts;

    public UIModel(int _startMoney = 100, int _startCourse = 2, int _startHearts = 3)
    {
        currentMoney = _startMoney;

        currentCourse = _startCourse;
        currentHearts = _startHearts;
    }
    public int CurrentMoney
    {
        get => currentMoney;
        set
        {
            if (currentMoney != value)
            {
                currentMoney = value;
                OnMoneyChanged?.Invoke(currentMoney);
            }

        }
    }
    public int CurrentHearts
    {
        get => currentHearts;
        set
        {
            if (currentHearts != value)
            {
                currentHearts = value;
                OnHeartsChanged?.Invoke(currentHearts);
            }

        }
    }
    public int CurrentCourse
    {
        get => currentCourse;
        set
        {
            if (CurrentCourse != value)
            {
                currentCourse = value;
                OnCourseChanged?.Invoke(currentCourse);
            }

        }
    }


}
