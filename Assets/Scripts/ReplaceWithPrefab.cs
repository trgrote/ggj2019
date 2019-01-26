using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Replaces Current Object with given prefab
public class ReplaceWithPrefab : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    public void Replace()
    {
        Destroy(this.gameObject);
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
