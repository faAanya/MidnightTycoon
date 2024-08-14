using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StationUpgrader : MonoBehaviour
{

    public Button button1, button2, button3, button4;
    public Station station;

    [HideInInspector]
    public UIView uIView;
    public GameObject stationUI;

    public UpgraderSO upgraderSO;

    void Start()
    {
        uIView = FindAnyObjectByType<UIView>();
        button1.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = upgraderSO.capacityCost.ToString();
        button2.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = upgraderSO.timeCost.ToString();
        button3.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = upgraderSO.courseCost.ToString();

        button1.onClick.AddListener(() =>
        {

            IncreaseCapacity();
            button1.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = upgraderSO.capacityCost.ToString();

        });
        button2.onClick.AddListener(() =>
        {
            DecreaseTime();
            button2.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = upgraderSO.timeCost.ToString();

        });
        button3.onClick.AddListener(() =>
        {
            ChangeCourse();
            button3.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = upgraderSO.courseCost.ToString();

        });
        button4.onClick.AddListener(() =>
        {
            stationUI.SetActive(false);
            Time.timeScale = 1;
        });
    }

    public void IncreaseCapacity()
    {
        int result = uIView.uIModel.CurrentMoney - upgraderSO.capacityCost;
        if (uIView.uIModel.CurrentMoney > 0 && result > 0)
        {
            station.capacity++;
            upgraderSO.capacityCost = (int)((upgraderSO.capacityCost + 2) * 1.5f);

            uIView.uIController.SpendMoney(upgraderSO.capacityCost);
        }

    }
    public void DecreaseTime()
    {
        if (uIView.uIModel.CurrentMoney > 0 && station.buyTime > 0)
        {
            station.buyTime--;
            upgraderSO.timeCost = (int)((upgraderSO.timeCost + 2) * 1.5f);

            uIView.uIController.SpendMoney(upgraderSO.timeCost);
        }
    }
    public void ChangeCourse()
    {
        int result = uIView.uIModel.CurrentMoney - upgraderSO.courseCost;
        if (uIView.uIModel.CurrentMoney > 0 && result > 0)
        {
            uIView.uIModel.CurrentCourse++;
            upgraderSO.courseCost = (int)((upgraderSO.courseCost + 2) * 1.5f);


            uIView.uIController.SpendMoney(upgraderSO.courseCost);

        }
    }

}
