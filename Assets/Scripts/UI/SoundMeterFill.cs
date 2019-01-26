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

    void Update()
    {
        _image.fillAmount = SoundMeterGlobals.SoundValue;
    }
}
