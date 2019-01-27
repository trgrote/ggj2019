using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyFaceObject : MonoBehaviour
{
    
    [SerializeField] private GameObject gameObjectToFace;
    private float angle;
    Rigidbody rb;

    void Start()
    {
    rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        FaceBody();
    }
    private void FaceBody()
    {
        var targetDir = gameObjectToFace.transform.position;
        var forward = transform.forward;
        var localTarget = transform.InverseTransformPoint(gameObjectToFace.transform.position);

        angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

        Vector3 eulerAngleVelocity = new Vector3(0, angle, 0);
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity); // FIXME Time.deltaTime???

        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
