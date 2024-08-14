using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuyStation : Shopping
{
    public GameObject station;
    public GameObject model;

    public void Start()

    {
        base.Start();
    }
    public override void Buy(ShopSO shopSO)
    {

        station.GetComponent<Station>().isBought = true;
        station.GetComponent<Station>().Start();

        gameObject.SetActive(false);
        base.Buy(shopSO);
    }
}
