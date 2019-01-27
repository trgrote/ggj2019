using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputHandler : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
        {
            switch (GlobalValues.State)
            {
                case State.WaitingForTony:
                    rho.GlobalEventHandler.SendEvent(new TonyBellucaEnterEvent());
                    break;
                case State.Menu:
                    rho.GlobalEventHandler.SendEvent(new MenuLeftEvent());
                    break;
                case State.Victory:
                case State.Failure:
                    rho.GlobalEventHandler.SendEvent(new LevelResetStartEvent());
                    break;
            }
        }
    }
}
