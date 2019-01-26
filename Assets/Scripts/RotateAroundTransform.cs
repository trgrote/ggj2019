using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundTransform : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _speed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (_target)
        {
            transform.LookAt(_target);
            transform.Translate(Vector3.right * Time.deltaTime * _speed);
        }
    }
}
