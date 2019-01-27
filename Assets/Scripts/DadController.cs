using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private float rotationFactor = 0.5f;
    Rigidbody rb;
    ConfigurableJoint weaponJoint;
    Quaternion weaponHighAngle;
    Quaternion weaponLowAngle;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        weaponJoint = GetComponent<ConfigurableJoint>();
        weaponHighAngle = Quaternion.AngleAxis(weaponJoint.highAngularXLimit.limit, Vector3.right);
        weaponLowAngle = Quaternion.AngleAxis(weaponJoint.lowAngularXLimit.limit, Vector3.right);
        print(weaponHighAngle);
        print(weaponLowAngle);
        print(Quaternion.Angle(weaponHighAngle, weaponLowAngle));
    }

    void FixedUpdate()
    {
        Movement();
        Rotation();
        BatHeight();
    }

    private void BatHeight()
    {
        // +1 for right trigger, -1 for left trigger
        float inputT = Input.GetAxisRaw("Trigger Axis");
        float normalizedInput = inputT * 0.5f + 0.5f;
        Quaternion targetRot = Quaternion.Slerp(weaponLowAngle, weaponHighAngle, normalizedInput);
        // print(normalizedInput.ToString() + targetRot.ToString());
        // Quaternion targetRot;
        // if (inputT < -0.5f) {
        //     targetRot = weaponHighAngle;
        // } else if (inputT > -0.5f) {
        //     targetRot = weaponLowAngle;
        // } else {
        //     targetRot = Quaternion.Euler(0,0,0);
        // }
        weaponJoint.targetRotation = targetRot;
    }

    private void Rotation()
    {
        float inputH = Input.GetAxisRaw("Right Stick Horizontal");
        float inputV = Input.GetAxisRaw("Right Stick Vertical");

        var horizAxis = Camera.main.transform.right;
        var vertAxis = Camera.main.transform.forward;

        // fuck y and then normalize
        horizAxis.y = vertAxis.y = 0;
        horizAxis.Normalize();
        vertAxis.Normalize();

        // Get Direction  
        var rotationInput = horizAxis * inputH + vertAxis * inputV;

        if (rotationInput.sqrMagnitude > 0.0f)
        {
            float rotationAngle = Vector3.SignedAngle(Vector3.forward, rotationInput, Vector3.up);
            Quaternion start = rb.rotation;
            Quaternion end = Quaternion.AngleAxis(rotationAngle, Vector3.up);
            rb.MoveRotation(Quaternion.Slerp(start, end, rotationFactor));
        }
    }

    private void Movement()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        var horizAxis = Camera.main.transform.right;
        var vertAxis = Camera.main.transform.forward;  // actualy z-axis

        // fuck y and then normalize
        horizAxis.y = vertAxis.y = 0;
        horizAxis.Normalize();
        vertAxis.Normalize();

        // Get Direction
        var moveDirection = horizAxis * inputH + vertAxis * inputV;

        rb.velocity = moveDirection * movementSpeed;

        // rb.AddForce(movement, ForceMode.VelocityChange);
    }
}
