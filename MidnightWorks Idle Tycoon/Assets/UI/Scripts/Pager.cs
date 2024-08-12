using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pager : MonoBehaviour
{
    public GameObject prevPage;
    public GameObject nextPage;
    public Button pager;

    public void Start()
    {
        pager.onClick.AddListener(() =>
        {
            prevPage.SetActive(false);
            nextPage.SetActive(true);
        });
    }

}
