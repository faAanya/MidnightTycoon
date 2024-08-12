using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        // Debug.Log($"{client.gameObject.name} Walk state");
    }
    void IState.Update()
    {
        if (!client.bought)
        {
            client.MoveClient(client.gameObject, client.aim.gameObject.transform.position, .33f);

            if (Vector3.Distance(client.transform.position, client.aim.gameObject.transform.position) < .5f && !client.bought)
            {
                client.StateMachine.ChangeState(client.StateMachine.ClientWaitState);
            }
        }
        if (client.bought && !client.canSit)
        {
            client.MoveClient(client.gameObject, client.startPos, .33f);
        }
        else if (client.canSit)
        {
            client.StateMachine.ChangeState(client.StateMachine.ClientSitState);
        }

    }

    public void Exit()
    {

    }


    // Start is called before the first frame update



}
