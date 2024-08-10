using UnityEngine;

public class Client : MonoBehaviour
{

    public UIView uIView;
    public Rigidbody rb;

    public Station aim;

    public Balance gameBalance;
    public Vector3 startPos;

    public bool bought;

    public bool canSit = false;
    public float hearts;
    public float money;

    public int queuePos = 0;

    public StateMachine StateMachine { get; private set; }

    void Start()
    {
        uIView = FindAnyObjectByType<UIView>();
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


    public void MoveClient(GameObject client, Vector3 target, float speed)
    {
        client.transform.position = Vector3.MoveTowards(client.transform.position, target, speed);
    }

}