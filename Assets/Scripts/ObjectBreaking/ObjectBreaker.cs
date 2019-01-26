using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBreaker : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        print("Collided with a breakable object");
        try
        {
            collision.gameObject.GetComponent<BreakableObject>().Break();
        }
        catch (System.NullReferenceException)
        {
            print("Object not breakable");
        }
    }
}
