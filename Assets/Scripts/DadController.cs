using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float movementSpeed = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal")) {
            transform.position += Input.GetAxis("Horizontal") * Vector3.right * Time.deltaTime * movementSpeed;
        }
        if (Input.GetButton("Vertical")) {
            transform.position += Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * movementSpeed;
        }
    }
}
