using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private float rotationFactor = 0.5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Input.GetAxis("Horizontal") * Vector3.right * Time.deltaTime * movementSpeed;
        transform.position += Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * movementSpeed;

        // Vector3 direction = Vector3.right * Input.GetAxisRaw("Right Stick Horizontal") +
        //     Vector3.forward * Input.GetAxisRaw("Right Stick Vertical");
        Vector2 rotationInput = new Vector2(Input.GetAxisRaw("Right Stick Horizontal"), Input.GetAxisRaw("Right Stick Vertical"));
        if (rotationInput.sqrMagnitude >= 0.0f) {
            float rotationAngle = Vector2.SignedAngle(Vector2.right, rotationInput);
            // Quaternion start = transform.rotation;
            // Quaternion end = Quaternion.AngleAxis(rotationAngle + 180.0f, Vector3.up);
            // transform.rotation = Quaternion.Slerp(start, end, rotationFactor);
            transform.rotation = Quaternion.AngleAxis(rotationAngle + 180.0f, Vector3.up);
        }
    }
}
