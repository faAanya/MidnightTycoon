using UnityEngine;


public class ClientBuyState : IState
{
    public Client client;

    public ClientBuyState(Client client)
    {
        this.client = client;
    }

    public void Enter()
    {
        Debug.Log("Buy State");
    }
    public void Update()
    {
        client.buyTime -= Time.deltaTime;
        if (client.buyTime <= 0 && !client.canSit)
        {
            client.bought = true;
            client.StateMachine.ChangeState(client.StateMachine.ClientWalkState);
        }
    }
    public void Exit()
    {

    }


}
