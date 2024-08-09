using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientWalkState : IState
{
    public Client client;

    public ClientWalkState(Client client)
    {
        this.client = client;
    }

    public void Enter()
    {
        Debug.Log("Walk state");
    }
    void IState.Update()
    {
        if (!client.bought)
        {
            MoveClient(client.gameObject, client.aim.transform.position, .33f);

            if (Vector3.Distance(client.transform.position, client.aim.transform.position) < .5f && !client.bought)
            {
                client.StateMachine.ChangeState(client.StateMachine.CLientBuyState);
            }
        }
        if (client.bought && !client.canSit)
        {
            MoveClient(client.gameObject, client.startPos, .33f);

        }
    }
    public void Exit()
    {

    }

    public void MoveClient(GameObject client, Vector3 target, float speed)
    {
        client.transform.position = Vector3.MoveTowards(client.transform.position, target, speed);

    }
    // Start is called before the first frame update



}
