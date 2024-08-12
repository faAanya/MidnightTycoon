using UnityEngine;


public class ClientSitState : IState
{
    public Client client;

    public ClientSitState(Client client)
    {
        this.client = client;
    }

    public void Enter()
    {
        Debug.Log($"{client.gameObject.name} Sit state");

    }
    public void Update()
    {
        client.MoveClient(client.gameObject, client.chair.transform.position, .33f);

        if (Vector3.Distance(client.gameObject.transform.position, client.chair.gameObject.transform.position) < 2)
        {
            client.timeToSit -= Time.deltaTime;
            if (client.timeToSit <= 0)
            {
                client.canSit = false;
                client.uIView.uIController.AddHearts(client.hearts);

                client.StateMachine.ChangeState(client.StateMachine.ClientWalkState);
            }
        }
    }
    public void Exit()
    {
        client.chair.GetComponent<Chair>().isBusy = false;
    }

}
