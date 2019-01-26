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
        SoundMeterGlobals.SoundValue = Mathf.Max(
            0f,
            SoundMeterGlobals.SoundValue -= _depleteRate * Time.deltaTime
        );
    }
}
