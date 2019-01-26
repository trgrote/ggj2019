using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This Fills up the sound meter image based off the curent Sound Value
[RequireComponent(typeof(Image))]
public class SoundMeterFill : MonoBehaviour
{
    Image _image;

    void Awake()
    {
        _image = GetComponent<Image>();
    }

    void OnEnable()
    {
        StartCoroutine(nameof(FillErUp));
    }

    void OnDisable()
    {
        StopCoroutine(nameof(FillErUp));
    }

    IEnumerator FillErUp()
    {
        while (true)
        {
            _image.fillAmount = SoundMeterGlobals.SoundValue;
            yield return null;
        }
    }
}
