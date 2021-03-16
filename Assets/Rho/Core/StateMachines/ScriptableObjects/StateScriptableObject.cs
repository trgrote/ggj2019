using System;
using UnityEngine;

namespace rho
{
    [CreateAssetMenu(menuName = "Rho/State Machine - State")]
    public class StateScriptableObject : ScriptableObject, IEquatable<StateScriptableObject>
    {
        public bool Equals(StateScriptableObject other) => ReferenceEquals(this, other);
    }
}