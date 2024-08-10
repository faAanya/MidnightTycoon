using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationUnpgrader : MonoBehaviour
{

    public Button button1, button2;
    public Station station;

    [HideInInspector]
    public UIView uIView;

    void Start()
    {
        uIView = FindAnyObjectByType<UIView>();

        button1.onClick.AddListener(() =>
        {
            IncreaseCapacity();
        });
        button2.onClick.AddListener(() => { DecreaseTime(); });
    }

    public void IncreaseCapacity()
    {
        if (uIView.uIModel.CurrentMoney > 0)
        {
            station.capacity++;
            uIView.uIController.SpendMoney(5);
        }

    }
    public void DecreaseTime()
    {
        if (uIView.uIModel.CurrentMoney > 0 && station.buyTime > 0)
        {
            station.buyTime--;
            uIView.uIController.SpendMoney(5);
        }
    }
}
