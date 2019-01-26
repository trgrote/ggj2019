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

  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  void FixedUpdate()
  {
    Movement();
    Rotation();
  }

  private void Rotation()
  {
    Vector2 rotationInput = new Vector2(Input.GetAxisRaw("Right Stick Horizontal"), Input.GetAxisRaw("Right Stick Vertical"));
    if (rotationInput.sqrMagnitude > 0.0f)
    {
      float rotationAngle = Vector2.SignedAngle(Vector2.right, rotationInput);
      Quaternion start = rb.rotation;
      Quaternion end = Quaternion.AngleAxis(rotationAngle + 180.0f, Vector3.up);
      rb.MoveRotation(Quaternion.Slerp(start, end, rotationFactor));
      // transform.rotation = Quaternion.Slerp(start, end, rotationFactor);
      // transform.rotation = Quaternion.AngleAxis(rotationAngle + 180.0f, Vector3.up);
    }
  }

  private void Movement()
  {
    float inputH = Input.GetAxis("Horizontal");
    float inputV = Input.GetAxis("Vertical");

    var horizAxis = Camera.main.transform.right;
    var vertAxis = Camera.main.transform.forward;

    // fuck y and then normalize
    horizAxis.y = vertAxis.y = 0;
    horizAxis.Normalize();
    vertAxis.Normalize();

    // Get Direction (should still be normalized)    
    var moveDirection = horizAxis * inputH + vertAxis * inputV;
    
    rb.velocity = moveDirection * movementSpeed;

    // rb.AddForce(movement, ForceMode.VelocityChange);
  }
}
