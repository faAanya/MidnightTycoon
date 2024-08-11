using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText, heartsText, courseText;
    public UIModel uIModel;
    public UIController uIController;

    private void Start()
    {
        uIModel = new UIModel();
        uIController = new UIController(uIModel);
        uIModel.OnMoneyChanged += UpdateMoneyText;
        uIModel.OnHertsChanged += UpdateHeartsText;
        uIModel.OnCourseChanged += UpdateCourseText;

    }

    private void UpdateMoneyText(float money)
    {
        moneyText.text = money.ToString();
    }
    private void UpdateHeartsText(int hearts)
    {
        heartsText.text = hearts.ToString();
    }
    private void UpdateCourseText(float course)
    {
        courseText.text = $"1 : {course}";
    }

}
