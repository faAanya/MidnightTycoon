using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIView : MonoBehaviour, IDataPersistence
{
    [SerializeField] private TextMeshProUGUI moneyText, heartsText, courseText;
    public UIModel uIModel;
    public UIController uIController;

    private void Awake()
    {

        uIModel = new UIModel();
        uIController = new UIController(uIModel);
        uIModel.OnMoneyChanged += UpdateMoneyText;
        uIModel.OnHeartsChanged += UpdateHeartsText;
        uIModel.OnCourseChanged += UpdateCourseText;

        moneyText.text = uIModel.CurrentMoney.ToString();
        heartsText.text = uIModel.CurrentHearts.ToString();
        courseText.text = uIModel.CurrentCourse.ToString();
    }

    private void UpdateMoneyText(int money)
    {
        moneyText.text = money.ToString();
    }
    private void UpdateHeartsText(int hearts)
    {
        heartsText.text = hearts.ToString();
    }
    private void UpdateCourseText(int course)
    {
        courseText.text = $"1 : {course}";
    }


    public void LoadData(GameData gameData)
    {
        Debug.Log("You load me");

        uIModel.CurrentMoney = gameData.money;
        uIModel.CurrentHearts = gameData.hearts;
        uIModel.CurrentCourse = gameData.course;
    }

    public void SaveData(ref GameData gameData)
    {
        Debug.Log("You saved me");
        gameData.money = uIModel.CurrentMoney;
        gameData.hearts = uIModel.CurrentHearts;
        gameData.course = uIModel.CurrentCourse;
    }
}
