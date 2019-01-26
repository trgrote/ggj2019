using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimitDepleter : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GlobalValues.TimeRemaining = Mathf.Max(0f, GlobalValues.TimeRemaining - Time.deltaTime);

        if (GlobalValues.TimeRemaining == 0f)
        {
            // Rip
            rho.GlobalEventHandler.SendEvent(new TimeRanOut());
        }
    }
}
