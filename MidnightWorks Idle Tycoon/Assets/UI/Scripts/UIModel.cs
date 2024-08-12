using System;
using UnityEngine;
public class UIModel
{
    public event Action<float> OnMoneyChanged, OnCourseChanged;
    public event Action<int> OnHeartsChanged;
    private float currentMoney, currentCourse;
    private int currentHearts;

    public UIModel()
    {

    }
    public float CurrentMoney
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
    public float CurrentCourse
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
