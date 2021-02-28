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
    
    public void onTonyBellucaEnter() 
    {
        EnableAll();
    }

    public void onMeterDepleted() 
    {
        DisableAll();
    }
    
    public void onMeterFilled() 
    {
        DisableAll();
    }
}
