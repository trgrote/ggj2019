using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stateless;

using SM=Stateless.StateMachine<GameStateManager.State,GameStateManager.Triggers>;

public class GameStateManager : MonoBehaviour
{
    public enum State
    {
        WaitingForDoorKick,
        BreakingState,
        SonWokeUp,
        Timeout
    }

    public enum Triggers
    {
        DoorKickedIn,
        TimeRanOut,
        MeterFilled
    }

    SM InitializeStatemachine()
    {
        var sm = new SM(State.WaitingForDoorKick);

        sm.Configure(State.WaitingForDoorKick)
            .Permit(Triggers.DoorKickedIn, State.BreakingState);

        sm.Configure(State.BreakingState)
            .Permit(Triggers.MeterFilled, State.SonWokeUp)
            .Permit(Triggers.TimeRanOut, State.Timeout);

        return sm;
    }

    SM _stateMachine;

    // Start is called before the first frame update
    void Awake()
    {
        _stateMachine = InitializeStatemachine();
    }
}
