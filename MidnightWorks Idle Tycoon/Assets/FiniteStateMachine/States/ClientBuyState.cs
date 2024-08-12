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
        // Debug.Log($"{client.gameObject.name} Buy State");
    }
    public void Update()
    {
        Chair[] chairs = GameObject.FindObjectsByType<Chair>(sortMode: FindObjectsSortMode.None);


        client.aim.StartTimer(client.queuePos);
        if (client.aim.queue[client.queuePos].buyTime <= 0 && !client.canSit)
        {
            client.uIView.uIController.AddMoney(client.money);
            client.uIView.uIController.AddHearts(client.hearts);


            client.bought = true;
            client.aim.queue[client.queuePos].isBusy = false;
            client.aim.ResetTimer(client.queuePos);

            for (int i = 0; i < chairs.Length; i++)
            {

                if (!chairs[i].isBusy)
                {
                    chairs[i].isBusy = true;
                    client.canSit = true;
                    client.chair = chairs[i].gameObject;
                    Debug.Log(client.chair.name);
                    break;
                }
            }

            client.StateMachine.ChangeState(client.StateMachine.ClientWalkState);
        }

    }
    public void Exit()
    {
        // Debug.Log($"{client.gameObject.name} Exit buy state");
    }


}
