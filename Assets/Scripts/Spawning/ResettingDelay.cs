using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When Reset happens, wait a bit before finishing the reset
public class ResettingDelay : MonoBehaviour
{   
    [SerializeField] rho.Event _levelResetFinishedEvent;

    public void OnLevelResetStarted()
    {
        StartCoroutine(nameof(DelayTillReset));
    }

    IEnumerator DelayTillReset()
    {
        yield return new WaitForSeconds(0.5f);
        _levelResetFinishedEvent.Raise();
    }
}
