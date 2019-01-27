using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Send Events based off keyboard input
public class TestEventSender : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rho.GlobalEventHandler.SendEvent(new MenuLeftEvent());
            print(nameof(MenuLeftEvent));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rho.GlobalEventHandler.SendEvent(new TonyBellucaEnterEvent());
            print(nameof(TonyBellucaEnterEvent));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rho.GlobalEventHandler.SendEvent(new MeterDepletedEvent());
            print(nameof(MeterDepletedEvent));
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            rho.GlobalEventHandler.SendEvent(new MeterFilledEvent());
            print(nameof(MeterFilledEvent));
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            rho.GlobalEventHandler.SendEvent(new LevelResetStartEvent());
            print(nameof(LevelResetStartEvent));
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            rho.GlobalEventHandler.SendEvent(new LevelResetFinishedEvent());
            print(nameof(LevelResetFinishedEvent));
        }
    }
}
