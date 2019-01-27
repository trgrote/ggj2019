﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SmoothTransition), typeof(LookAtTransform))]
public class SceneCameraTransitions : MonoBehaviour
{
    [SerializeField] Transform _menuPosition;
    [SerializeField] Transform _menuLookTarget;
    [SerializeField] Transform _beforeEnterPosition;
    [SerializeField] Transform _beforeEnterLookTarget;
    [SerializeField] Transform _afterEnterPosition;
    Transform _afterEnterLookTarget;
    [SerializeField] Transform _failurePosition;
    Transform _failureLookTarget;
    [SerializeField] Transform _victoryPosition;
    Transform _victoryLookTarget;

    SmoothTransition _smooth;
    LookAtTransform _look;

    [SerializeField, TagSelector] string PlayerTag;
    [SerializeField, TagSelector] string BedTag;

    Transform FindTaggedTransform(string tag)
    {
        var obj = GameObject.FindGameObjectWithTag(tag);
        return obj?.transform;
    }

    #region Monobehavior

    void Awake()
    {
        _smooth = GetComponent<SmoothTransition>();
        _look = GetComponent<LookAtTransform>();
    }

    void Start()
    {
        // SImulate a reset
        OnLevelResetFinished(null);
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

    #endregion

    // TODO Add Dynamic Tony and Bed Finding Algos
    // TODO Intergrate Fade in/out effects

    #region Event Handling

    void OnMenuExit(MenuLeftEvent evt)
    {
        _smooth.StartTransition(_beforeEnterPosition.position);
        _look.Target = _beforeEnterLookTarget;
    }

    void OnTonyBellucaEnter(TonyBellucaEnterEvent evt)
    {
        _afterEnterLookTarget = FindTaggedTransform(PlayerTag);

        _smooth.StartTransition(_afterEnterPosition.position);
        _look.Target = _afterEnterLookTarget;
    }

    void OnMeterDepleted(MeterDepletedEvent evt)
    {
        _failureLookTarget = FindTaggedTransform(BedTag);

        _smooth.StartTransition(_failurePosition.position);
        _look.Target = _failureLookTarget;
    }

    void OnMeterFilled(MeterFilledEvent evt)
    {
        _victoryLookTarget = FindTaggedTransform(PlayerTag);
        
        _smooth.StartTransition(_victoryPosition.position);
        _look.Target = _victoryLookTarget;
    }

    private void OnLevelResetStart(LevelResetStartEvent evt)
    {
    }

    void OnLevelResetFinished(LevelResetFinishedEvent evt)
    {
        _smooth.StartTransition(_menuPosition.position);
        _look.Target = _menuLookTarget;
    }

    #endregion
}