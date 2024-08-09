using UnityEngine;

public class Client : MonoBehaviour
{

    public Rigidbody rb;

    public Station aim;

    public Balance gameBalance;
    public Vector3 startPos;

    public bool bought;

    public bool canSit = false;
    public float hearts;
    public float money;

    public StateMachine StateMachine { get; private set; }

    void Start()
    {
        gameBalance = FindAnyObjectByType<Balance>();
        aim = FindAnyObjectByType<Station>();
        rb = GetComponent<Rigidbody>();
        StateMachine = new StateMachine(this);
        StateMachine.Initialize(StateMachine.ClientWalkState);
        startPos = gameObject.transform.position;

    }
    void Update()
    {
        StateMachine.Update();
    }

    public void GiveMoney(float money)
    {
        gameBalance.balance += money;
    }
    public void GiveHearts(int hearts)
    {

    }

    public void MoveClient(GameObject client, Vector3 target, float speed)
    {
        client.transform.position = Vector3.MoveTowards(client.transform.position, target, speed);
    }

}