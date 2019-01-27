using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTransform : MonoBehaviour
{
    public Transform Target;

    [SerializeField] float _speed = 5f;

    void Update()
    {
        if (Target != null)
        {
            // transform.LookAt(Target, Vector3.up);
            var targetRotation = Quaternion.LookRotation(
                Target.position - transform.position);
       
            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(
                transform.rotation, 
                targetRotation, 
                _speed * Time.deltaTime
            );
        }
    }
}
