using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Just slow depletes the current sound value
public class SoundMeterDepleter : MonoBehaviour
{
    [Tooltip("unit per second")]
    [SerializeField] float _depleteRate;

    void Update()
    {
        GlobalValues.SoundValue = Mathf.Max(
            0f,
            GlobalValues.SoundValue -= _depleteRate * Time.deltaTime
        );
    }
}
