using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerFirstController : MonoBehaviour
{
  // Start is called before the first frame update
  [SerializeField] private float movementSpeed = 5.0f;
  Rigidbody rb;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  void FixedUpdate()
  {
    // Movement();
    Orbit();
  }

  private void Orbit()
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
      rb.velocity = movementSpeed * rotationInput;
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
