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
  [SerializeField] private float mouseRotationFactor = 1.0f;
  private float rotationAngle = 180.0f;

  void Start()
  {
    rb = GetComponent<Rigidbody>();

    Cursor.lockState = CursorLockMode.Locked;

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
    float inputH = Input.GetAxisRaw("Rotation X");
    float inputV = Input.GetAxisRaw("Rotation Y");

    Transform cameraTransform = Camera.main.transform;
    var horizAxis = cameraTransform.right;
    var vertAxis = cameraTransform.forward;

    // fuck y and then normalize
    horizAxis.y = vertAxis.y = 0;
    horizAxis.Normalize();
    vertAxis.Normalize();

    // Get Direction  
    var rotationInput = horizAxis * inputH + vertAxis * inputV;

    
    float mouseX = Input.GetAxis("Mouse X");
    if (rotationInput.sqrMagnitude > 0.0f)
    {
      rotationAngle = Vector3.SignedAngle(Vector3.forward, rotationInput, Vector3.up);
    }
    else if (Math.Abs(mouseX) > 0.0f)
    {
      // print(mouseX);
      rotationAngle += mouseX * mouseRotationFactor;
    };
    ProcessRotationToAngle(rotationAngle);
  }

  private void ProcessRotationToAngle(float rotationAngle)
  {
    Quaternion start = rb.rotation;
    Quaternion end = Quaternion.AngleAxis(rotationAngle, Vector3.up);
    rb.MoveRotation(Quaternion.Slerp(start, end, rotationFactor));
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
