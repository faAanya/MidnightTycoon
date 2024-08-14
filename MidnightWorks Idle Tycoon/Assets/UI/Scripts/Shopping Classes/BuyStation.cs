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
        station.GetComponent<Station>().enabled = true;
        station.GetComponent<PlayerInput>().enabled = true;
        model.SetActive(true);
        gameObject.SetActive(false);
        base.Buy(shopSO);
    }
}
