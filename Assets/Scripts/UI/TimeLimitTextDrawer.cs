using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimeLimitTextDrawer : MonoBehaviour
{
    Text _text;

    // Start is called before the first frame update
    void Awake()
    {
        _text = GetComponent<Text>();    
    }

    // Update is called once per frame
    void Update()
    {
        var minutes = Mathf.FloorToInt(GlobalValues.TimeRemaining / 60f);
        var seconds = Mathf.FloorToInt(GlobalValues.TimeRemaining % 60f);
        _text.text = String.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
