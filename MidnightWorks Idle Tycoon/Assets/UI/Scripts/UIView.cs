using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private UIModel uIModel;
    [HideInInspector] public UIController uIController;

    private void Start()
    {
        uIModel = new UIModel();
        uIController = new UIController(uIModel);

        uIModel.OnMoneyChanged += UpdateText;
    }

    private void UpdateText(float money)
    {
        text.text = "Money" + money.ToString();
    }

}
