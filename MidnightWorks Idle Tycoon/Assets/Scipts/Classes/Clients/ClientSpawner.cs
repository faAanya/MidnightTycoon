using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    public int counter = 0;
    public float coolDown = 3f;
    public bool canSpawn;


    public List<GameObject> clients;
    void Start()
    {
        canSpawn = true;
    }

    void Update()
    {
        if (canSpawn)
        {
            System.Random random = new System.Random();

            GameObject newClient = Instantiate(clients[random.Next(0, clients.Count)], gameObject.transform.position, Quaternion.identity);
            counter++;
            newClient.name = $"Client № {counter}";
            canSpawn = false;
        }
        coolDown -= Time.deltaTime;
        if (coolDown <= 0)
        {
            canSpawn = true;
            coolDown = 3f;
        }
    }
}
