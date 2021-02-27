using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rho
{
    [CreateAssetMenu(menuName = "Rho/Event")]
    public class Event : ScriptableObject
    {
        List<EventListener> _listeners = new List<EventListener>();

        public void Raise(params object[] args)
        {
            for (var i = _listeners.Count - 1; i >= 0 ; --i)
            {
                _listeners[i].OnEventRaised(args);
            }
        }

        public void Register(EventListener listener)
        {
            _listeners.Add(listener);
        }

        public void Unregister(EventListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}