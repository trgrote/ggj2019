using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        rho.GlobalEventHandler.Register<MenuLeftEvent>(OnMenuExit);
        rho.GlobalEventHandler.Register<TonyBellucaEnterEvent>(OnTonyBellucaEnter);
        rho.GlobalEventHandler.Register<MeterDepletedEvent>(OnMeterDepleted);
        rho.GlobalEventHandler.Register<MeterFilledEvent>(OnMeterFilled);
        rho.GlobalEventHandler.Register<LevelResetStartEvent>(OnLevelResetStart);
        rho.GlobalEventHandler.Register<LevelResetFinishedEvent>(OnLevelResetFinished);
    }

    void OnDisable()
    {
        rho.GlobalEventHandler.Unregister<MenuLeftEvent>(OnMenuExit);
        rho.GlobalEventHandler.Unregister<TonyBellucaEnterEvent>(OnTonyBellucaEnter);
        rho.GlobalEventHandler.Unregister<MeterDepletedEvent>(OnMeterDepleted);
        rho.GlobalEventHandler.Unregister<MeterFilledEvent>(OnMeterFilled);
        rho.GlobalEventHandler.Unregister<LevelResetStartEvent>(OnLevelResetStart);
        rho.GlobalEventHandler.Unregister<LevelResetFinishedEvent>(OnLevelResetFinished);
    }

    IEnumerator WaitForTonyStartInput()
    {
        while (true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                break;
            }
            yield return null;
        }

        rho.GlobalEventHandler.SendEvent(new TonyBellucaEnterEvent());
    }

    private void OnLevelResetStart(LevelResetStartEvent evt)
    {
        StopCoroutine(nameof(WaitForTonyStartInput));
    }

    private void OnMeterFilled(MeterFilledEvent evt)
    {
        StopCoroutine(nameof(WaitForTonyStartInput));
    }

    private void OnMeterDepleted(MeterDepletedEvent evt)
    {
        StopCoroutine(nameof(WaitForTonyStartInput));
    }

    private void OnTonyBellucaEnter(TonyBellucaEnterEvent evt)
    {
        Spawn();
    }

    private void OnMenuExit(MenuLeftEvent evt)
    {
        StartCoroutine(nameof(WaitForTonyStartInput));
    }

    private void OnLevelResetFinished(LevelResetFinishedEvent evt)
    {
        // Unspawn tony
        var tony = GameObject.FindGameObjectWithTag(PlayerTag);

        if (tony)
        {
            Destroy(tony);
        }
    }
}
