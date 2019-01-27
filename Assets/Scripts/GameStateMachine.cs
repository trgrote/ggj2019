using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    public enum State
    {
        Menu,
        WaitingForTony,
        GameMode,
        Victory,
        Failure,
        Resetting
    }

    public State _state = State.Menu;

    // Start is called before the first frame update
    void OnEnable()
    {
        rho.GlobalEventHandler.Register<MenuLeftEvent>(OnMenuExit);
        rho.GlobalEventHandler.Register<TonyBellucaEnterEvent>(OnTonyBellucaEnter);
        rho.GlobalEventHandler.Register<MeterDepletedEvent>(OnMeterDepleted);
        rho.GlobalEventHandler.Register<MeterFilledEvent>(OnMeterFilled);
        rho.GlobalEventHandler.Register<LevelResetStartEvent>(OnLevelResetStart);
        rho.GlobalEventHandler.Register<LevelResetFinishedEvent>(OnLevelResetFinished);
    }

    void OnDisable()
    {
        rho.GlobalEventHandler.Unregister<MenuLeftEvent>(OnMenuExit);
        rho.GlobalEventHandler.Unregister<TonyBellucaEnterEvent>(OnTonyBellucaEnter);
        rho.GlobalEventHandler.Unregister<MeterDepletedEvent>(OnMeterDepleted);
        rho.GlobalEventHandler.Unregister<MeterFilledEvent>(OnMeterFilled);
        rho.GlobalEventHandler.Unregister<LevelResetStartEvent>(OnLevelResetStart);
        rho.GlobalEventHandler.Unregister<LevelResetFinishedEvent>(OnLevelResetFinished);
    }

    #region Event Handling

    void OnMenuExit(MenuLeftEvent evt)
    {
        _state = State.WaitingForTony;
    }

    void OnTonyBellucaEnter(TonyBellucaEnterEvent evt)
    {
        _state = State.GameMode;
    }

    void OnMeterDepleted(MeterDepletedEvent evt)
    {
        _state = State.Failure;
    }

    void OnMeterFilled(MeterFilledEvent evt)
    {
        _state = State.Victory;
    }

    private void OnLevelResetStart(LevelResetStartEvent evt)
    {
        _state = State.Resetting;
    }

    void OnLevelResetFinished(LevelResetFinishedEvent evt)
    {
        _state = State.Menu;
    }

    #endregion
}
