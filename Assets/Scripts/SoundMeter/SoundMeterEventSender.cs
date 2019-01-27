using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMeterEventSender : MonoBehaviour
{
    void Update()
    {
        if (GlobalValues.SoundValue >= 1.0f)
        {
            rho.GlobalEventHandler.SendEvent(new MeterFilledEvent());
        }
        else if (GlobalValues.SoundValue <= 0 )
        {
            rho.GlobalEventHandler.SendEvent(new MeterDepletedEvent());
        }
    }
}
