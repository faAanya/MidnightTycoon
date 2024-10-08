using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Exchanger : MonoBehaviour
{
    public UIView uIView;
    public Slider slider;

    public Button exchange;

    public TextMeshProUGUI min, max, current;
    public Button openButton, closeButton;
    public GameObject exchangeOpen;
    void Start()
    {
        openButton.onClick.AddListener(() => { exchangeOpen.SetActive(true); Time.timeScale = 0; });
        closeButton.onClick.AddListener(() => { exchangeOpen.SetActive(false); Time.timeScale = 1; });


        min.text = slider.minValue.ToString();
        max.text = slider.maxValue.ToString();
        current.text = slider.value.ToString();
        exchange.onClick.AddListener(Exchange);
    }

    void Exchange()
    {
        if (uIView.uIModel.CurrentHearts >= (int)slider.value)
        {
            uIView.uIController.Exchange((int)slider.value, uIView.uIModel.CurrentCourse);
        }
    }
    // Update is called once per frame
    void Update()
    {
        current.text = ((int)slider.value).ToString();
    }
}
