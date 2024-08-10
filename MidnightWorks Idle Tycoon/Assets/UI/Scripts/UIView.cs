using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText, heartsText;
    public UIModel uIModel;
    [HideInInspector] public UIController uIController;

    private void Start()
    {
        uIModel = new UIModel();
        uIController = new UIController(uIModel);

        uIModel.OnMoneyChanged += UpdateMoneyText;
        uIModel.OnHertsChanged += UpdateHeartsText;
    }

    private void UpdateMoneyText(float money)
    {
        moneyText.text = money.ToString();
    }
    private void UpdateHeartsText(int hearts)
    {
        heartsText.text = hearts.ToString();
    }

}
