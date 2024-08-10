using System;
public class UIModel
{
    public event Action<float> OnMoneyChanged;
    private float currentMoney;

    public UIModel(float startMoney = 0)
    {
        CurrentMoney = startMoney;
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

}
