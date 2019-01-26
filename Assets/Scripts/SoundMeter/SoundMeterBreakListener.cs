using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main Job is to listen for Break Events and update the current sound value
public class SoundMeterBreakListener : MonoBehaviour
{
    #region MonoBehavior

    void OnEnable()
    {
        rho.GlobalEventHandler.Register<ObjectBrokenEvent>(OnObjectBroken);
    }

    void OnDisable()
    {
        rho.GlobalEventHandler.Unregister<ObjectBrokenEvent>(OnObjectBroken);
    }

    #endregion

    void OnObjectBroken(ObjectBrokenEvent evt)
    {
        // Add Value to the Sound Value
        SoundMeterGlobals.SoundValue += evt.SoundAmount;
    }
}
