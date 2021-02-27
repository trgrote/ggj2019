using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rho.ExternalVariables
{
    public class ExternalVariable<T> : ScriptableObject
    {
        public T Value;
    }
}