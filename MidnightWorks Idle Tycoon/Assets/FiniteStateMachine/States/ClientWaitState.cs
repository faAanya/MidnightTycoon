using UnityEngine;


public class ClientWaitState : IState
{
    public Client client;

    public ClientWaitState(Client client)
    {
        this.client = client;
    }

    public void Enter()
    {
        Debug.Log($"{client.gameObject.name}  Wait State");
    }
    public void Update()
    {
        for (int i = 0; i < client.aim.queue.Length; i++)
        {
            if (!client.aim.queue[i].isBusy)
            {
                client.aim.queue[i].isBusy = true;
                client.queuePos = i;
                client.StateMachine.ChangeState(client.StateMachine.ClientBuyState);
                break;
            }
            else
            {
                Debug.Log($"{client.gameObject.name} I'm staying in queue");
            }
        }

    }
    public void Exit()
    {

    }

}
