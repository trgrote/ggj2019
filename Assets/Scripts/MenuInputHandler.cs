using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputHandler : MonoBehaviour
{
    [SerializeField] rho.Event _tonyEnterEvent;
    [SerializeField] rho.Event _menuLeftEvent;
    [SerializeField] rho.Event _resetStartEvent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
        {
            switch (GlobalValues.State)
            {
                case State.WaitingForTony:
                    _tonyEnterEvent.Raise();
                    break;
                case State.Menu:
                    _menuLeftEvent.Raise();
                    break;
                case State.Victory:
                case State.Failure:
                    _resetStartEvent.Raise();
                    break;
            }
        }
    }
}
