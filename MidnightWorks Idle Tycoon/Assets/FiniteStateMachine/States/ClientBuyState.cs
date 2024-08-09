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
        client.aim.buyTime -= Time.deltaTime;
        if (client.aim.buyTime <= 0 && !client.canSit)
        {
            client.GiveMoney(client.money);
            client.bought = true;
            client.StateMachine.ChangeState(client.StateMachine.ClientWalkState);
            client.aim.buyTime = 7f;
        }

    }
    public void Exit()
    {
        Debug.Log("Exit buy state");
    }


}
