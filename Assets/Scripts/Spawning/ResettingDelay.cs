using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When Reset happens, wait a bit before finishing the reset
public class ResettingDelay : MonoBehaviour
{
    void OnEnable()
    {
        rho.GlobalEventHandler.Register<LevelResetStartEvent>(OnLevelResetStarted);
    }

    void OnDisable()
    {
        rho.GlobalEventHandler.Unregister<LevelResetStartEvent>(OnLevelResetStarted);
    }
    
    private void OnLevelResetStarted(LevelResetStartEvent evt)
    {
        StartCoroutine(nameof(DelayTillReset));
    }

    IEnumerator DelayTillReset()
    {
        yield return new WaitForSeconds(0.5f);
        rho.GlobalEventHandler.SendEvent(new LevelResetFinishedEvent());
    }
}
