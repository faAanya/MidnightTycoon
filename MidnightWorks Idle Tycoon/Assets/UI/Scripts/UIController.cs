using System.Collections;
using System.Collections.Generic;
using System.Net.Cache;
using UnityEngine;

public class UIController
{
    private UIModel uIModel;

    public UIController(UIModel _uIModel)
    {
        uIModel = _uIModel;
    }

    public void AddMoney(float money)
    {
        uIModel.CurrentMoney += money;
    }

    public void SpendMoney(float money)
    {
        uIModel.CurrentMoney -= money;
    }
    public void AddHearts(int hearts)
    {
        uIModel.CurrentHearts += hearts;
    }
    public void SpendHearts(int hearts)
    {
        uIModel.CurrentHearts -= hearts;
    }

    public void Exchange(int hearts, float course)
    {
        float addedMoney = hearts * course;

        AddMoney(addedMoney);
        SpendHearts(hearts);
    }



}
