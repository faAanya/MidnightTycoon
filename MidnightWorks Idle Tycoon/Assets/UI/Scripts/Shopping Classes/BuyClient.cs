using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuyClient : Shopping
{


    // Update is called once per frame
    public override void Buy(ShopSO shopSO)
    {
        ClientSpawner[] spawners = GameObject.FindObjectsOfType<ClientSpawner>();

        for (int i = 0; i < spawners.Length; i++)
        {
            if (!spawners[i].clients.Contains(shopSO.product))
            {
                spawners[i].clients.Add(shopSO.product);
                base.Buy(shopSO);
            }
        }

    }
}
