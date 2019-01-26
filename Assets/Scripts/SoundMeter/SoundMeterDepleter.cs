using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Just slow depletes the current sound value
public class SoundMeterDepleter : MonoBehaviour
{
    [Tooltip("unit per second")]
    [SerializeField] float _depleteRate;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(nameof(Deplete));
    }

    void OnDisable()
    {
        StopCoroutine(nameof(Deplete));
    }

    IEnumerator Deplete()
    {
        while (true)
        {
            SoundMeterGlobals.SoundValue = Mathf.Max(
                0f,
                SoundMeterGlobals.SoundValue -= _depleteRate * Time.deltaTime
            );
            yield return null;
        }
    }
}
