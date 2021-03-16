using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace rho
{
    [CustomEditor(typeof(StateVariable))]
    public class StateVariableEditor : BaseExternalVariableEditor<StateScriptableObject>
    {
        protected override StateScriptableObject GetFieldValue()
        {
            return (StateScriptableObject) EditorGUILayout.ObjectField("Value", _variable.Value, typeof(StateScriptableObject), false);
        }
    }
}