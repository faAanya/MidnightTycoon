using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public IState CurrentState { get; private set; }

    public ClientWalkState ClientWalkState;
    public ClientBuyState ClientBuyState;
    public ClientWaitState ClientWaitState;
    public ClientSitState ClientSitState;



    public StateMachine(Client client)
    {
        this.ClientWalkState = new ClientWalkState(client);
        this.ClientBuyState = new ClientBuyState(client);
        this.ClientWaitState = new ClientWaitState(client);
        this.ClientSitState = new ClientSitState(client);
    }

    public void Initialize(IState StartingState)
    {
        CurrentState = StartingState;
        StartingState.Enter();
    }

    public void ChangeState(IState NextState)
    {
        CurrentState.Exit();
        CurrentState = NextState;
        NextState.Enter();
    }
    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
}
