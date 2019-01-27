using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBreaker : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) 
    {
        collision.gameObject.GetComponent<BreakableObject>()?.Break();
    }
}
