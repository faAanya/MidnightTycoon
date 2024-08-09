using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    public int amount;
    public float coolDown = 3f;
    public bool canSpawn;

    public GameObject client;
    void Start()
    {
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn && amount != 0)
        {
            GameObject newClient = Instantiate(client, transform.position, Quaternion.identity);
            canSpawn = false;
            amount--;
        }
        coolDown -= Time.deltaTime;
        if (coolDown <= 0)
        {
            canSpawn = true;
            coolDown = 3f;
        }
    }
}
