using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
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
        GlobalValues.State = State.WaitingForTony;
    }

    void OnTonyBellucaEnter(TonyBellucaEnterEvent evt)
    {
        GlobalValues.State = State.GameMode;
    }

    void OnMeterDepleted(MeterDepletedEvent evt)
    {
        GlobalValues.State = State.Failure;
    }

    void OnMeterFilled(MeterFilledEvent evt)
    {
        GlobalValues.State = State.Victory;
    }

    private void OnLevelResetStart(LevelResetStartEvent evt)
    {
        GlobalValues.State = State.Resetting;
    }

    void OnLevelResetFinished(LevelResetFinishedEvent evt)
    {
        GlobalValues.State = State.Menu;
    }

    #endregion
}
