﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] Animator _animator;

    // Start is called before the first frame update
    void OnEnable()
    {
        rho.GlobalEventHandler.Register<MeterDepletedEvent>(OnMeterDepleted);
        rho.GlobalEventHandler.Register<MeterFilledEvent>(OnMeterFilled);
        rho.GlobalEventHandler.Register<LevelResetFinishedEvent>(OnLevelResetFinished);
    }

    void OnDisable()
    {
        rho.GlobalEventHandler.Unregister<MeterDepletedEvent>(OnMeterDepleted);
        rho.GlobalEventHandler.Unregister<MeterFilledEvent>(OnMeterFilled);
        rho.GlobalEventHandler.Unregister<LevelResetFinishedEvent>(OnLevelResetFinished);
    }

    #region Event Handling

    public void OnMenuExit()
    {
        _animator.SetTrigger("Ready");
        GlobalValues.State = State.WaitingForTony;
    }

    public void OnTonyBellucaEnter()
    {
        _animator.SetTrigger("EnterGameMode");
        GlobalValues.State = State.GameMode;
    }

    void OnMeterDepleted(MeterDepletedEvent evt)
    {
        _animator.SetTrigger("Failure");
        GlobalValues.State = State.Failure;
    }

    void OnMeterFilled(MeterFilledEvent evt)
    {
        _animator.SetTrigger("Victory");
        GlobalValues.State = State.Victory;
    }

    public void OnLevelResetStart()
    {
        _animator.SetTrigger("Reset");
        GlobalValues.State = State.Resetting;
        GlobalValues.SoundValue = GlobalValues.InitialSoundValue;
    }

    void OnLevelResetFinished(LevelResetFinishedEvent evt)
    {        
        GlobalValues.State = State.Menu;
    }

    #endregion
}
