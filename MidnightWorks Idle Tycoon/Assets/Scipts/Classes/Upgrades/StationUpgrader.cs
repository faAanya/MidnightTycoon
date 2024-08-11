using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationUpgrader : MonoBehaviour
{

    public Button button1, button2, button3;
    public Station station;

    [HideInInspector]
    public UIView uIView;
    public GameObject stationUI;


    void Start()
    {
        uIView = FindAnyObjectByType<UIView>();

        button1.onClick.AddListener(() =>
        {
            IncreaseCapacity();
        });
        button2.onClick.AddListener(() => { DecreaseTime(); });

        button3.onClick.AddListener(() =>
        {
            stationUI.SetActive(false);
            Time.timeScale = 1;
        });
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
