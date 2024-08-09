using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public IState CurrentState { get; private set; }

    public ClientWalkState ClientWalkState;
    public ClientBuyState CLientBuyState;



    public StateMachine(Client client)
    {
        this.ClientWalkState = new ClientWalkState(client);
        this.CLientBuyState = new ClientBuyState(client);
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
