using System;
public class UIModel
{
    public event Action<float> OnMoneyChanged;
    public event Action<int> OnHertsChanged;
    private float currentMoney;
    private int currentHearts;

    public UIModel(float startMoney = 0, int startHearts = 0)
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

}
