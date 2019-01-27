﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Just Smoothly Move from current position to target destination
public class SmoothTransition : MonoBehaviour
{
    [SerializeField] AnimationCurve _animCurve;
    [SerializeField] float _transitionTime = 1f;

    public void StartTransition(Vector3 position)
    {
        StopCoroutine(nameof(Transition));
        StartCoroutine(nameof(Transition), position);
    }
    
    #region Coroutine

    IEnumerator _coroutine;

    IEnumerator Transition(Vector3 target)
    {
        var start = transform.position;
        var distance = target - start;
        var elsapedTime = 0f;

        while (transform.position != target)
        {
            transform.position = start + _animCurve.Evaluate(elsapedTime / _transitionTime) * distance;
            yield return null;
            elsapedTime += Time.deltaTime;
        }
    }

    #endregion
}
