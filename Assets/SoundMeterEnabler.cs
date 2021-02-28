using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMeterEnabler : MonoBehaviour
{
    private SoundMeterBreakListener soundMeterBreakListener;
    private SoundMeterDepleter soundMeterDepleter;
    private SoundMeterEventSender soundMeterEventSender;
    void Start()
    {
        soundMeterBreakListener = GetComponent<SoundMeterBreakListener>();
        soundMeterDepleter = GetComponent<SoundMeterDepleter>();
        soundMeterEventSender = GetComponent<SoundMeterEventSender>();

        DisableAll();
    }

    private void DisableAll()
    {
        soundMeterBreakListener.enabled = false;
        soundMeterDepleter.enabled = false;
        soundMeterEventSender.enabled = false;
    }

    private void EnableAll()
    {
        soundMeterBreakListener.enabled = true;
        soundMeterDepleter.enabled = true;
        soundMeterEventSender.enabled = true;
    }

    void OnEnable()
    {
        rho.GlobalEventHandler.Register<MeterDepletedEvent>(onMeterDepleted);
        rho.GlobalEventHandler.Register<MeterFilledEvent>(onMeterFilled);
        rho.GlobalEventHandler.Register<LevelResetFinishedEvent>(onLevelResetFinished);
    }

    void OnDisable()
    {
        rho.GlobalEventHandler.Unregister<MeterDepletedEvent>(onMeterDepleted);
        rho.GlobalEventHandler.Unregister<MeterFilledEvent>(onMeterFilled);
        rho.GlobalEventHandler.Unregister<LevelResetFinishedEvent>(onLevelResetFinished);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onTonyBellucaEnter() 
    {
        EnableAll();
    }

    void onMeterDepleted(MeterDepletedEvent evt) {
        DisableAll();
    }
    
    void onMeterFilled(MeterFilledEvent evt) {
        DisableAll();
    }
    
    void onLevelResetFinished(LevelResetFinishedEvent evt) {

    }
}
