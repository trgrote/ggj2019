using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMeterEventSender : MonoBehaviour
{
    [SerializeField] rho.Event _meterFilledEvent;
    [SerializeField] rho.Event _meterDepletedEvent;

    void Update()
    {
        if (GlobalValues.SoundValue >= 1.0f)
        {
            _meterFilledEvent.Raise();
        }
        else if (GlobalValues.SoundValue <= 0 )
        {
            _meterDepletedEvent.Raise();
        }
    }
}
