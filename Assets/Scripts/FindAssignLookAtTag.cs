using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

// When FindAndAssign is called, it will search for the first object it can find with the given tag and 
// assign the new camera's lookat transform to this tagged gameobject's transform
public class FindAssignLookAtTag : MonoBehaviour
{
    [SerializeField, TagSelector] string _tag;

    public void FindAndAssign(ICinemachineCamera currentCamera, ICinemachineCamera prevCamera)
    {
        var obj = GameObject.FindGameObjectWithTag(_tag);
        currentCamera.LookAt = obj?.transform;
    }
}
