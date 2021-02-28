using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rho;

public class TonySpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    [SerializeField, TagSelector] string PlayerTag;

    public void Spawn()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }

    void OnEnable()
    {
        rho.GlobalEventHandler.Register<LevelResetFinishedEvent>(OnLevelResetFinished);
    }

    void OnDisable()
    {
        rho.GlobalEventHandler.Unregister<LevelResetFinishedEvent>(OnLevelResetFinished);
    }
    public void OnTonyBellucaEnter()
    {
        Spawn();
    }

    private void OnLevelResetFinished(LevelResetFinishedEvent evt)
    {
        // Unspawn tony
        var tony = GameObject.FindGameObjectWithTag(PlayerTag);

        if (tony)
        {
            // kill his parent
            Destroy(tony.transform.parent.gameObject);
        }
    }
}
