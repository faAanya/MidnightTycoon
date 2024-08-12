using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{

    public UIView uIView;
    public Rigidbody rb;

    public Station aim;

    public Vector3 startPos;

    public bool bought;

    public bool canSit = false;
    public int hearts;
    public float money, timeToSit;

    public int queuePos = 0;

    public GameObject chair;

    public StateMachine StateMachine { get; private set; }

    void Start()
    {
        chair = null;
        uIView = FindAnyObjectByType<UIView>();
        aim = FindAnyObjectByType<Station>();
        rb = GetComponent<Rigidbody>();
        StateMachine = new StateMachine(this);

        aim = FindClosestallStation();

        StateMachine.Initialize(StateMachine.ClientWalkState);
        startPos = gameObject.transform.position;

    }
    void Update()
    {
        if (bought && transform.position == startPos)
        {
            Destroy(gameObject);
        }
        StateMachine.Update();
    }


    public void MoveClient(GameObject client, Vector3 target, float speed)
    {
        client.transform.position = Vector3.MoveTowards(client.transform.position, target, speed);
    }
    Station FindClosestallStation() //looks for closest cafe
    {
        float distanceToClosestStation = Mathf.Infinity;
        Station closestStation = null;
        IEnumerable<Station> allStations = FindObjectsOfType<Station>();

        foreach (Station currentStation in allStations)
        {
            float distanceToStation = (currentStation.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToStation < distanceToClosestStation)
            {
                distanceToClosestStation = distanceToStation;
                closestStation = currentStation;
            }
        }
        return closestStation;

    }
}