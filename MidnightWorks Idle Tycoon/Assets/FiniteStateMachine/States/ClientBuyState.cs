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
        Debug.Log($"{client.gameObject.name} Buy State");
    }
    public void Update()
    {
        client.aim.StartTimer(client.queuePos);
        if (client.aim.queue[client.queuePos].buyTime <= 0 && !client.canSit)
        {
            client.uIView.uIController.AddMoney(client.money);
            client.bought = true;
            client.aim.queue[client.queuePos].isBusy = false;
            client.aim.ResetTimer(client.queuePos);



            client.StateMachine.ChangeState(client.StateMachine.ClientWalkState);
        }

    }
    public void Exit()
    {
        Debug.Log($"{client.gameObject.name} Exit buy state");
    }


}
