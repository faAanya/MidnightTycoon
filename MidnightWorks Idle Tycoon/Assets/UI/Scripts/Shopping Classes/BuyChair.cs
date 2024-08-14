using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyChair : Shopping
{
    public PlaceWithChairs placeWithChairs;

    public override void Buy(ShopSO shopSO)
    {
        if (placeWithChairs.capacity < placeWithChairs.maxCapacity)
        {
            placeWithChairs.capacity++;
            GameObject newChair = Instantiate(placeWithChairs.chair.gameObject, placeWithChairs.transform.position, Quaternion.identity);
            placeWithChairs.chairsGO.Add(newChair);
            newChair.transform.SetParent(placeWithChairs.gameObject.transform);
            for (int i = 0, j = 0; i < placeWithChairs.chairsGO.Count && j < 360; i++, j += 360 / placeWithChairs.chairsGO.Count)
            {
                Vector3 pos = new Vector3(.5f * Mathf.Cos(j * Mathf.PI / 180) + placeWithChairs.gameObject.transform.position.x, placeWithChairs.gameObject.transform.position.y, .5f * Mathf.Sin(j * Mathf.PI / 180) + placeWithChairs.gameObject.transform.position.z);
                placeWithChairs.chairsGO[i].transform.position = new Vector3(pos.x, pos.y, pos.z);
                placeWithChairs.chairsGO[i].transform.rotation = Quaternion.Euler(0, (j + 180f) * Mathf.Pow(-1, i), 0);

            }
            // placeWithChairs.DestroyChairs();
            // placeWithChairs.BuildChairs();
        }
    }
}
