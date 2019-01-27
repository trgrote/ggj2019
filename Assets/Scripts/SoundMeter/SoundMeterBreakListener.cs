using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main Job is to listen for Break Events and update the current sound value
public class SoundMeterBreakListener : MonoBehaviour
{
    #region MonoBehavior
    [SerializeField] [Range(0.0f, 1.0f)] private float soundValueScale = 1.0f;

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
        GlobalValues.SoundValue += evt.SoundAmount * soundValueScale;
    }
}
