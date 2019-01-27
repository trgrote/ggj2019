using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownOnBreak : MonoBehaviour
{
    [Tooltip("What the timescale should be when we are slow motioning")]
    [SerializeField] float _slowTimeScale;

    [Tooltip("How long we should stay in this slow motion, unscaled")]
    [SerializeField] float _slowTimeDuration;

    void OnEnable()
    {
        rho.GlobalEventHandler.Register<ObjectBrokenEvent>(OnObjectBroken);
    }

    void OnDisable()
    {
        rho.GlobalEventHandler.Unregister<ObjectBrokenEvent>(OnObjectBroken);
    }

    private void OnObjectBroken(ObjectBrokenEvent evt)
    {
        // Start Slow Coroutine
        StartSlowDown();
    }

    #region Corotuine

    bool _slowMotionOn = false;
    IEnumerator _coroutine = null;

    void StartSlowDown()
    {
        if (_slowMotionOn)
        {
            StopSlowDown();
        }

        StartCoroutine(_coroutine = SlowDown());
    }

    void StopSlowDown()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        Time.timeScale = 1f;
        _slowMotionOn = false;
    }

    IEnumerator SlowDown()
    {
        _slowMotionOn = true;
        Time.timeScale = _slowTimeScale;
        yield return new WaitForSecondsRealtime(_slowTimeDuration);
        Time.timeScale = 1f;
        _slowMotionOn = false;
    }

    #endregion
}
