using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BreakableObject))]
[RequireComponent(typeof(Collider))]
public class TestBreakOnClick : MonoBehaviour
{
    void OnMouseDown()
    {
        GetComponent<BreakableObject>().Break();
    }
}
