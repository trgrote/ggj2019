using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rho;

public class ResetDoor : MonoBehaviour
{
    Vector3 _initalPosition;
    Quaternion _initialiRotation;

    [SerializeField, TagSelector] string DoorTag;

    void Start()
    {
        var door = GameObject.FindGameObjectWithTag(DoorTag);
        var rb = door.GetComponent<Rigidbody>();
        _initalPosition = rb.position;
        _initialiRotation = rb.rotation;
    }

    public void OnLevelResetFinished()
    {
        var door = GameObject.FindGameObjectWithTag(DoorTag);
        var rb = door.GetComponent<Rigidbody>();
        rb.position = _initalPosition;
        rb.rotation = _initialiRotation;
        rb.velocity = Vector3.zero;
    }
}
