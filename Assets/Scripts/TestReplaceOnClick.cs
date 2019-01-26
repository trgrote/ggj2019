using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ReplaceWithPrefab))]
[RequireComponent(typeof(Collider))]
public class TestReplaceOnClick : MonoBehaviour
{
    void OnMouseDown()
    {
        GetComponent<ReplaceWithPrefab>().Replace();
    }
}
