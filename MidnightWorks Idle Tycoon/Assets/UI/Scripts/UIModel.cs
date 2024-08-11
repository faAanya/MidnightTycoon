using System;
public class UIModel
{
    public event Action<float> OnMoneyChanged, OnCourseChanged;
    public event Action<int> OnHertsChanged;
    private float currentMoney, currentCourse;
    private int currentHearts;

    public UIModel(float startMoney = 0, int startHearts = 0, float startCourse = 4)
    {
        CurrentMoney = startMoney;
        CurrentHearts = startHearts;
        CurrentCourse = startCourse;
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
                OnHertsChanged?.Invoke(currentHearts);
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
