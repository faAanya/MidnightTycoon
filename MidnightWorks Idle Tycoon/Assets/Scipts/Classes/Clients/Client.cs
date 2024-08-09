using UnityEngine;

public class Client : MonoBehaviour
{

    public Rigidbody rb;
    public GameObject aim;
    public Vector3 startPos;

    public bool bought;

    public float buyTime;
    public bool canSit = false;
    public float hearts;
    public float money;

    public StateMachine StateMachine { get; private set; }

    void Start()
    {
        startPos = gameObject.transform.position;
        rb = GetComponent<Rigidbody>();
        StateMachine = new StateMachine(this);
        StateMachine.Initialize(StateMachine.ClientWalkState);
    }
    void Update()
    {
        StateMachine.Update();
    }

}