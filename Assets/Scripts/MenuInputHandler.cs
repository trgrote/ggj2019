using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputHandler : MonoBehaviour
{
    [SerializeField] rho.Event _menuLeftEvent;

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
                    _menuLeftEvent.Raise();
                    break;
                case State.Victory:
                case State.Failure:
                    rho.GlobalEventHandler.SendEvent(new LevelResetStartEvent());
                    break;
            }
        }
    }
}
