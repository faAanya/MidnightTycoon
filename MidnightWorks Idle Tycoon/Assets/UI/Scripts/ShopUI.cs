using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject shopBlock;
    public Button openButton, exitButton;


    public void Start()
    {
        openButton.onClick.AddListener(() => { shopBlock.SetActive(true); Time.timeScale = 0; });
        exitButton.onClick.AddListener(() => { shopBlock.SetActive(false); Time.timeScale = 1; });
        shopBlock.SetActive(false);

    }
}
